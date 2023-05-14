
using AutoMapper;
using Domain_Layer.Entities;
using Domain_Layer.Models.Result;

namespace Application_Layer
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<Role, CreateRoleResult>();
            CreateMap<User, CreateUserResult>();
            CreateMap<Category, CreateCategoryResult>();
            CreateMap<Service, CreateServiceResult>();
            CreateMap<Turn, CreateTurnResult>();
            CreateMap<ServiceTurn, CreateServiceTurnResult>();
        }
    }
}
