using AutoMapper;
using Microsoft.AspNetCore.Components.Routing;
using Practica_CRUD.Class;
using Practica_CRUD.Class.ClassDto;

namespace Practica_CRUD.Mapper
{
    public class Mapper : Profile
    {
        public Mapper()
        {
                CreateMap<UserDto, User>();
                CreateMap<User,UserDto>();

                CreateMap<RolDto, Rol>();
                CreateMap<Rol, RolDto>();
                
                CreateMap<RolUser, RolUserDto>();
                CreateMap<RolUserDto, RolUser>();

        }
    }
}
