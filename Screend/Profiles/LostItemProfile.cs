using AutoMapper;
using Screend.Entities.LostItem;
using Screend.Models.LostItem;

namespace Screend.Profiles
{
    public class LostItemProfile : Profile
    {
        public LostItemProfile()
        {
            CreateMap<LostItem, LostItemDTO>()
                .ReverseMap();
            CreateMap<LostItem, LostItemCreateUpdateDTO>()
                .ReverseMap();
        }
    }
}