using System;
using System.Collections.Generic;
using System.Linq;
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
    }
    
    public class OrderService : BaseService, IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IScheduleRepository _scheduleRepository;
        private readonly IOrderChairRepository _orderChairRepository;
        private readonly IMovieTicketRepository _movieTicketRepository;
        private readonly ITheaterChairRepository _theaterChairRepository;

        public OrderService(
            IOrderRepository orderRepository,
            IScheduleRepository scheduleRepository,
            IOrderChairRepository orderChairRepository,
            IMovieTicketRepository movieTicketRepository,
            ITheaterChairRepository theaterChairRepository
        )
        {
            _orderRepository = orderRepository;
            _scheduleRepository = scheduleRepository;
            _orderChairRepository = orderChairRepository;
            _movieTicketRepository = movieTicketRepository;
            _theaterChairRepository = theaterChairRepository;
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
            
            Order order = new Order
            {
                UserId = 1,
                Paid = 0,
                MollieId = mollieId
            };
            
            _orderRepository.Insert(order);
            
            foreach (var orderChair in orderDto.OrderChairs)
            {
                var bookedChair = _orderChairRepository.Get(it =>
                    it.TheaterChairId == orderChair.ChairId && it.ScheduleId == schedule.Id).FirstOrDefault();
                if (bookedChair != null)
                {
                    throw new BadRequestException("Chair already booked");
                }

                var ticket = _movieTicketRepository.GetByID(orderChair.TicketId);

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
                    MovieTicket = ticket,
                    TheaterChair = chair,
                    Order = order
                });
            }
            
            _orderRepository.Commit();
            
            return order;
        }
    }
}