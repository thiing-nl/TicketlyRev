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
        Order Create(OrderCreateDTO orderDto, string mollieId);

        Order GetById(int id);

        void Update(Order order);

        Order UpdateChairs(int orderId, ICollection<OrderUpdateChairDTO> orderUpdateChairDtos);

        void DeleteById(int orderId);
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

        public Order UpdateChairs(int orderId, ICollection<OrderUpdateChairDTO> orderUpdateChairDtos)
        {
            var order = GetById(orderId);

            foreach (var orderChair in order.OrderChairs)
            {
                foreach (var orderUpdateChairDto in orderUpdateChairDtos)
                {
                    if (orderUpdateChairDto.ChairdId == orderChair.TheaterChairId)
                    {
                        var chair = _theaterChairRepository.GetByID(orderUpdateChairDto.ChairUpdateId);

                        if (
                            chair == null 
                            || orderChair.Schedule.TheaterId != chair.TheaterRow.TheaterId
                        )
                        {
                            throw new NotFoundException("Chair not found");
                        }

                        var bookedChair =
                            _orderChairRepository.GetOrderChairByChairIdAndScheduleId(orderUpdateChairDto.ChairUpdateId,
                                orderChair.ScheduleId);

                        if (bookedChair != null)
                        {
                            throw new BadRequestException("Chair already booked");
                        }

                        orderChair.TheaterChairId = chair.Id;
                        orderChair.TheaterChair = chair;
                    }
                }
            }
            
            _orderRepository.Commit();            
            return order;
        }

        public void DeleteById(int orderId)
        {
            var order = GetById(orderId);
            _orderRepository.Delete(order);
            _orderRepository.Commit();
        }
    }
}