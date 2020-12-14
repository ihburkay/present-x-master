using AutoMapper;
using WebApi.Dto;
using WebApi.Entities;

namespace WebApi.Profiles{
    public class UsersProfile: Profile{
        public UsersProfile()
        {
            //Source=>target
            CreateMap<UserCreateDto,User>();
            CreateMap<User,UserReadDto>();
        }
    }
}