using AutoMapper;
using Domain_Layer.Entities;
using Domain_Layer.Persistence.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Application_Layer.Endpoints.Roles
{
    [ApiController]
    public class Create : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly IRoleRepository _roleRepository;
        public Create(IMapper mapper, IRoleRepository roleRepository)
        {
            _mapper = mapper;
            _roleRepository = roleRepository;
        }

        [HttpPost("api/CreateRole")]
        public async Task<ActionResult<CreateRoleResult>> CreateRole(CreateRoleCommand request)
        {
            try
            {
                Rol role = SetRoleObject(request);

                var roleCreated = await _roleRepository.CreateRoleAsync(role);

                var result = _mapper.Map<CreateRoleResult>(roleCreated);

                return Created("", result);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private static Rol SetRoleObject(CreateRoleCommand roleData)
        {
            return new Rol
            {
                Description = roleData.Description
            };
        }
    }
}
