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
        Order Create(OrderCreateDTO orderDto);
    }
    
    public class OrderService : BaseService, IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMovieRepository _movieRepository;
        private readonly IScheduleRepository _scheduleRepository;
        private readonly IOrderChairRepository _orderChairRepository;
        private readonly IMovieTicketRepository _movieTicketRepository;
        private readonly ITheaterChairRepository _theaterChairRepository;

        public OrderService(
            IOrderRepository orderRepository,
            IMovieRepository movieRepository,
            IScheduleRepository scheduleRepository,
            IOrderChairRepository orderChairRepository,
            IMovieTicketRepository movieTicketRepository,
            ITheaterChairRepository theaterChairRepository
        )
        {
            _orderRepository = orderRepository;
            _movieRepository = movieRepository;
            _scheduleRepository = scheduleRepository;
            _orderChairRepository = orderChairRepository;
            _movieTicketRepository = movieTicketRepository;
            _theaterChairRepository = theaterChairRepository;
        }

        public Order Create(OrderCreateDTO orderDto)
        {            
            var schedule = _scheduleRepository.GetByID(orderDto.ScheduleId);

            if (schedule == null)
            {
                throw new NotFoundException("Schedule not found");
            }
            
            Order order = new Order
            {
                UserId = 1,
                Paid = 1,
                MollieId = "1234"
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