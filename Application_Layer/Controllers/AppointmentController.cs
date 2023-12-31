﻿using AutoMapper;
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
    public class AppointmentController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IServiceTurnRepository _serviceTurnRepository;
        private readonly IUserRepository _userRepository;
        public AppointmentController(
            IMapper mapper, 
            IAppointmentRepository appointmentRepository, 
            IServiceTurnRepository serviceTurnRepository,
            IUserRepository userRepository)
        {
            _mapper = mapper;
            _appointmentRepository = appointmentRepository;
            _serviceTurnRepository = serviceTurnRepository;
            _userRepository = userRepository;
        }

        [HttpPost("CreateAppointment")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<CreateAppointmentResult>> CreateAppointment(CreateAppointmentCommand request)
        {
            try
            {
                Client client = await _userRepository.GetClientAsync(request.ClientId);

                Beautician beautician = await _userRepository.GetBeauticianAsync(request.BeauticianId);

                ServiceTurn serviceTurn = await _serviceTurnRepository.GetServiceTurnAsync(request.ServiceId, request.TurnId);

                if (client is not Client)
                {
                    return BadRequest("Client not found.");
                }
                else if (beautician is not Beautician)
                {
                    return BadRequest("Beautician not found.");
                }
                
                if (serviceTurn is not ServiceTurn)
                {
                    return BadRequest("ServiceTurn not found.");
                }

                Appointment appointment = SetAppointmentObject(request);

                var appointmentCreated = await _appointmentRepository.CreateAppointmentAsync(appointment);

                var result = _mapper.Map<CreateAppointmentResult>(appointmentCreated);

                return Created("Appointment created.", result);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("GetClientAppointments/{clientId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<List<CreateAppointmentResult>>> GetClientAppointments(int clientId)
        {
            try
            {
                List<Appointment> appointments = await _appointmentRepository.GetAppointmentsByClientId(clientId);

                if (appointments.Count == 0)
                {
                    return BadRequest("There are no appointments for this client.");
                }

                var result = _mapper.Map<List<CreateAppointmentResult>>(appointments);

                return Ok(result);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("GetBeauticianAppointments/{beauticianId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<List<CreateAppointmentResult>>> GetBeauticianAppointments(int beauticianId)
        {
            try
            {
                List<Appointment> appointments = await _appointmentRepository.GetAppointmentsByBeauticianId(beauticianId);

                if (appointments.Count == 0)
                {
                    return BadRequest("There are no appointments for this beautician.");
                }

                var result = _mapper.Map<List<CreateAppointmentResult>>(appointments);

                return Ok(result);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("GetAppointment/{appointmentId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<CreateAppointmentResult>> GetAppointment(int appointmentId)
        {
            try
            {
                Appointment appointment = await _appointmentRepository.GetAppointmentByIdAsync(appointmentId);

                if (appointment is null)
                {
                    return BadRequest("Appointment not found.");
                }

                var result = _mapper.Map<CreateAppointmentResult>(appointment);

                return Ok(result);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private static Appointment SetAppointmentObject(CreateAppointmentCommand appointment)
        {
            return new Appointment
            {
                Description = appointment.Description,
                Date = appointment.Date,
                BeauticianId = appointment.BeauticianId,
                ClientId = appointment.ClientId,
                ServiceId = appointment.ServiceId,
                TurnId = appointment.TurnId 
            };
        }
    }
}
