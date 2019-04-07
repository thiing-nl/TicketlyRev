using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore.Internal;
using Screend.Entities.Location;
using Screend.Entities.Order;
using Screend.Exceptions;
using Screend.Models.Order;
using Screend.Repositories;

namespace Screend.Services
{
    public interface IOrderService
    {
        ICollection<Order> GetAllOrders();
        Order Create(OrderCreateDTO orderDto, string mollieId);

        Order GetById(int id);

        void Update(Order order);
    }
    
    public class OrderService : BaseService, IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ITicketRepository _ticketRepository;
        private readonly IScheduleRepository _scheduleRepository;
        private readonly IOrderChairRepository _orderChairRepository;
        private readonly ITheaterChairRepository _theaterChairRepository;
        private readonly ILocationMovieRepository _locationMovieRepository;

        public OrderService(
            IOrderRepository orderRepository,
            ITicketRepository ticketRepository,
            IScheduleRepository scheduleRepository,
            IOrderChairRepository orderChairRepository,
            ITheaterChairRepository theaterChairRepository,
            ILocationMovieRepository locationMovieRepository
        )
        {
            _orderRepository = orderRepository;
            _ticketRepository = ticketRepository;
            _scheduleRepository = scheduleRepository;
            _orderChairRepository = orderChairRepository;
            _theaterChairRepository = theaterChairRepository;
            _locationMovieRepository = locationMovieRepository;
        }

        public ICollection<Order> GetAllOrders()
        {
            return _orderRepository.GetAll().ToArray();
        }

        public void Update(Order update)
        {
            var order = GetById(update.Id);
            order.Paid = update.Paid;
            _orderRepository.Commit();
        }
        public Order GetById(int id)
        {
            var order =  _orderRepository.GetByID(id);
            if (order == null)
            {
                throw new NotFoundException("Order not found");
            }
            return order;
        }

        public Order Create(OrderCreateDTO orderDto, string mollieId)
        {            
            var schedule = _scheduleRepository.GetByID(orderDto.ScheduleId);

            if (schedule == null)
            {
                throw new NotFoundException("Schedule not found");
            }

            var locationMovie =
                _locationMovieRepository.GetLocationMovieByLocationIdAndMovieId(schedule.LocationId, schedule.MovieId);
            
            if (locationMovie == null)
            {
                throw new NotFoundException("Movie at this location not found");
            }
            
            var order = new Order
            {
                UserId = 1,
                Paid = 0,
                MollieId = mollieId,
                LocationMovie = locationMovie
            };
            
            _orderRepository.Insert(order);
            
            foreach (var orderChair in orderDto.OrderChairs)
            {
                var bookedChair =
                    _orderChairRepository.GetOrderChairByChairIdAndScheduleId(orderChair.ChairId, schedule.Id);
                
                if (bookedChair != null)
                {
                    throw new BadRequestException("Chair already booked");
                }

                var ticket = _ticketRepository.GetByID(orderChair.TicketId);

                if (ticket == null)
                {
                    throw new BadRequestException("Ticket not found");
                }

                var chair = _theaterChairRepository.GetByID(orderChair.ChairId);

                if (chair == null)
                {
                    throw new NotFoundException("Chair not found");
                }
                
                _orderChairRepository.Insert(new OrderChair
                {
                    Schedule = schedule,
                    Ticket = ticket,
                    TheaterChair = chair,
                    Order = order
                });
            }
            
            _orderRepository.Commit();
            
            return order;
        }
        
    }
}