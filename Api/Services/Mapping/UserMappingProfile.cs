using Api.Data.Entities;
using Api.Domain.Models.DTOs;
using Api.Domain.Models.Entities;
using AutoMapper;

namespace Api.Services.Mapping;

public class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        CreateMap<UserRegisterRequest, UserEntity>();
        CreateMap<UserLoginRequest, UserEntity>();
        CreateMap<UserEntity, User>();
        CreateMap<BaseUser, AppBaseUser>();
    }
}