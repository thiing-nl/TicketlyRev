using System.Collections.Generic;
using System.Linq;
using Moq;
using Screend.Entities.Order;
using Screend.Exceptions;
using Xunit;
using Screend.Services;
using Screend.Repositories;

namespace Screend.Tests.Services
{
    public class OrderServiceTest
    {
        private static OrderService _orderService;
        static int OrderId = 1;
        static string MollieId = "Mollie_1234";
        
        static OrderServiceTest()
        {
            Setup();
        }

        private static void Setup()
        {
            var orderRepository = new Mock<IOrderRepository>();
            var ticketRepository = new Mock<ITicketRepository>();
            var scheduleRepository = new Mock<IScheduleRepository>();
            var orderChairRepository = new Mock<IOrderChairRepository>();
            var theaterChairRepository = new Mock<ITheaterChairRepository>();
            var locationMovieRepository = new Mock<ILocationMovieRepository>();

            var orders = new List<Order>();
            var order = new Order
            {
                Id = OrderId,
                MollieId = MollieId
            };
            
            orders.Add(order);
            
            orderRepository.Setup(x => x.GetAll()).Returns(orders.AsQueryable);
            orderRepository.Setup(x => x.GetByID(OrderId)).Returns(order);
            
            _orderService = new OrderService(
                orderRepository.Object, 
                ticketRepository.Object,
                scheduleRepository.Object,
                orderChairRepository.Object,
                theaterChairRepository.Object,
                locationMovieRepository.Object
            );
        }
        
        [Fact]
        public void GetAllOrdersTest()
        {
            var orders = _orderService.GetAllOrders();
            Assert.Equal(1, orders.Count);
        }

        [Fact]
        public void GetByIdTest()
        {
            var order = _orderService.GetById(OrderId);
            Assert.Equal(MollieId, order.MollieId);
        }

        [Fact]
        public void GetByIdNotFoundTest()
        {
            Assert.Throws<NotFoundException>(() => _orderService.GetById(87));
        }
        
    }
}