using Screend.Repositories;

namespace Screend.Services
{
    public interface IOrderService
    {
    }
    
    public class OrderService : BaseService, IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
    }
}