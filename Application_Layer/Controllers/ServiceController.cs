using AutoMapper;
using Domain_Layer.Entities;
using Domain_Layer.Models.Command;
using Domain_Layer.Models.Result;
using Domain_Layer.Persistence.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Application_Layer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceRepository _serviceRepository;
        private readonly IMapper _mapper;
        public ServiceController(IServiceRepository serviceRepository, IMapper mapper)
        {
            _serviceRepository = serviceRepository;
            _mapper = mapper;
        }

        [HttpPost("CreateService")]
        public async Task<ActionResult<CreateServiceResult>> CreateService(CreateServiceCommand request)
        {
            try
            {
                Service service = SetServiceObject(request);

                var serviceCreated = await _serviceRepository.CreateServiceAsync(service);

                var result = _mapper.Map<CreateServiceResult>(serviceCreated);

                return Created("Service created", result);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private static Service SetServiceObject(CreateServiceCommand service)
        {
            return new Service()
            {
                Description = service.Description,
                CategoryId = service.CategoryId
            };
        }
    }
}
