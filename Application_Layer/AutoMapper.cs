
using AutoMapper;
using Domain_Layer.Entities;
using Domain_Layer.Models.Result;

namespace Application_Layer
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<Role, RoleResult>();
            CreateMap<User, UserResult>();
            CreateMap<Category, CategoryResult>();
        }
    }
}
