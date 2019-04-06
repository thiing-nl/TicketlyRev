using AutoMapper;
using Screend.Entities.Order;
using Screend.Models.Order;

namespace Screend.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderDTO>().ReverseMap();
            CreateMap<OrderChair, OrderChairDTO>().ReverseMap();
        }
    }
}