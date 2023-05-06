using AutoMapper;
using Domain_Layer.Entities;
using Domain_Layer.Models.Command;
using Domain_Layer.Models.Result;
using Domain_Layer.Persistence.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Application_Layer.Endpoints
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {

            private readonly IMapper _mapper;
            private readonly IRoleRepository _roleRepository;
            public RoleController(IMapper mapper, IRoleRepository roleRepository)
            {
                _mapper = mapper;
                _roleRepository = roleRepository;
            }

            [HttpPost("CreateRole")]
            public async Task<ActionResult<RoleResult>> CreateRole(RoleCommand request)
            {
                try
                {
                    Role role = SetRoleObject(request);

                    var roleCreated = await _roleRepository.CreateRoleAsync(role);

                    var result = _mapper.Map<RoleResult>(roleCreated);

                    return Created("", result);
                }
                catch (Exception)
                {

                    throw;
                }
            }
            
            private static Role SetRoleObject(RoleCommand roleData)
            {
                return new Role
                {
                    Description = roleData.Description
                };
            }
        }
}
