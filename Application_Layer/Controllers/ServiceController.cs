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
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public ServiceController(IServiceRepository serviceRepository, ICategoryRepository categoryRepository, IMapper mapper)
        {
            _serviceRepository = serviceRepository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        [HttpPost("CreateService")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<CreateServiceResult>> CreateService(CreateServiceCommand request)
        {
            try
            {

                Category category = await _categoryRepository.GetCategoryByIdAsync(request.CategoryId);

                if (category is null)
                {
                    return NotFound("Category not found.");
                }

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

        [HttpGet("GetCategoryServices/{categoryId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<List<CreateServiceResult>>> GetCategoryServices(int categoryId)
        {
            try
            {
                var services = await _serviceRepository.GetServicesByCategoryId(categoryId);

                if (services.Count == 0)
                {
                    return NotFound("There are no services with this categoryId");
                }

                var result = _mapper.Map<List<CreateServiceResult>>(services);

                return Ok(result);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("GetService/{serviceId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<CreateServiceResult>> GetService(int serviceId)
        {
            try
            {
                Service service = await _serviceRepository.GetServiceByIdAsync(serviceId);

                if (service is null)
                {
                    return NotFound("Service not found.");
                }

                var result = _mapper.Map<CreateServiceResult>(service);

                return Ok(result);
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
