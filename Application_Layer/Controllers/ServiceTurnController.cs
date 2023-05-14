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
    public class ServiceTurnController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IServiceTurnRepository _serviceTurnRespository;
        private readonly IServiceRepository _serviceRepository;
        private readonly ITurnRepository _turnRepository;
        public ServiceTurnController(IMapper mapper, IServiceTurnRepository serviceTurnRepository, IServiceRepository serviceRepository, ITurnRepository turnRepository)
        {
            _mapper = mapper;
            _serviceTurnRespository = serviceTurnRepository;
            _serviceRepository = serviceRepository;
            _turnRepository = turnRepository;
        }

        [HttpPost("CreateServiceTurn")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<CreateServiceTurnResult>> CreateServiceTurn(CreateServiceTurnCommand request)
        {
            try
            {
                Turn turn = await _turnRepository.GetTurnByIdAsync(request.TurnId);

                Service service = await _serviceRepository.GetServiceByIdAsync(request.ServiceId);

                if (turn is null)
                {
                    return NotFound("Turn not found.");
                }
                else if (service is null)
                {
                    return NotFound("Service not found.");
                }
                
                ServiceTurn serviceTurn = SetServiceTurnObject(request);

                var serviceTurnCreated = await _serviceTurnRespository.CreateServiceTurnAsync(serviceTurn);

                var result = _mapper.Map<CreateServiceTurnResult>(serviceTurnCreated);

                return Created("ServiceTurn created.", result);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("GetTurnsService/{serviceId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<List<CreateServiceTurnResult>>> GetTurnsOfService(int serviceId)
        {
            try
            {
                List<ServiceTurn> turnsOfService = await _serviceTurnRespository.GetTurnsOfService(serviceId);

                if (turnsOfService.Count == 0)
                {
                    return BadRequest("There are no Turns for this Service.");
                }

                var result = _mapper.Map<List<CreateServiceTurnResult>>(turnsOfService);

                return Ok(result);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private static ServiceTurn SetServiceTurnObject(CreateServiceTurnCommand serviceTurn)
        {
            return new ServiceTurn
            {
                ServiceId = serviceTurn.ServiceId,
                TurnId = serviceTurn.TurnId
            };
        }
    }
}
