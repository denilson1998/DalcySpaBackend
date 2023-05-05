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
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IServiceRepository _serviceRepository;
        public ServiceController(IMapper mapper, ICategoryRepository categoryRepository, IServiceRepository serviceRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
            _serviceRepository = serviceRepository;
        }

        [HttpPost("CreateService")]
        public async Task<ActionResult<ServiceResult>> CreateService(ServiceCommand command)
        {
            try
            {
                Category category = await _categoryRepository.GetCategoryById(command.CategoryId);

                if (category is null)
                {
                    return BadRequest("Category not found");
                }

                Service service = SetServiceObject(command);

                var serviceCreated = await _serviceRepository.CreateServiceAsync(service);

                var result = _mapper.Map<ServiceResult>(serviceCreated);

                return Created("Service Created", result);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        private static Service SetServiceObject(ServiceCommand service)
        {
            return new Service
            {
                Description = service.Description,
                CategoryId = service.CategoryId
            };
        }
    }
}
