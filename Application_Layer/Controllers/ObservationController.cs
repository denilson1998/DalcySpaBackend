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
    public class ObservationController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IObservationRepository _observationRepository;
        public ObservationController(
            IMapper mapper,
            IAppointmentRepository appointmentRepository,
            IObservationRepository observationRepository)
        {
            _mapper = mapper;
            _appointmentRepository = appointmentRepository;
            _observationRepository = observationRepository;
        }

        [HttpPost("CreateObservation")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<CreateObservationResult>> CreateObservation(CreateObservationCommand request)
        {
            try
            {
                Appointment appointment = await _appointmentRepository.GetAppointmentByIdAsync(request.AppointmentId);

                if (appointment is null)
                {
                    return NotFound("Appointment not found.");
                }

                Observation observation = SetObservationObject(request);

                var observationCreated = await _observationRepository.CreateObservationAsync(observation);

                var result = _mapper.Map<CreateObservationResult>(observationCreated);

                return Created("Observation created.", result);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private static Observation SetObservationObject(CreateObservationCommand observation)
        {
            return new Observation
            {
                Diagnosis = observation.Diagnosis,
                Description = observation.Description,
                AppointmentId = observation.AppointmentId
            };
        }
    }
}
