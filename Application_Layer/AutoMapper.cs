using Application_Layer.Endpoints.Roles;
using AutoMapper;
using Domain_Layer.Entities;

namespace Application_Layer
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<Rol, CreateRoleResult>();
        }
    }
}
