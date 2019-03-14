using System.Linq;
using AutoMapper;
using Microsoft.VisualBasic.CompilerServices;
using Screend.Entities.User;
using Screend.Models.User;

namespace Screend.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserRegisterDTO, User>();
            CreateMap<User, UserDTO>();
            CreateMap<UserToken, UserTokenDTO>();
            CreateMap<User, AuthorizedUserDTO>()
                .ForMember(ut => ut.Token, 
                    expression => expression.MapFrom((dto, cache) => dto.Tokens.LastOrDefault()));
        }
    }
}