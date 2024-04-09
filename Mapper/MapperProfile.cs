using AutoMapper;
using MyLearningRoomBackend.Dto;
using MyLearningRoomBackend.Models;

namespace MyLearningRoomBackend.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile() 
        {
            CreateMap<UserDto, UserModel>();
            CreateMap<UserModel, UserDto>();
        }
    }
}
