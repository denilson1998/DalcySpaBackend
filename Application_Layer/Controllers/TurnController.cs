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
    public class TurnController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ITurnRepository _turnRepository;
        public TurnController(IMapper mapper, ITurnRepository turnRepository)
        {
            _mapper = mapper;
            _turnRepository = turnRepository;
        }

        [HttpPost("CreateTurn")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<CreateTurnResult>> CreateTurn(CreateTurnCommand request)
        {
            try
            {
                Turn turn = SetTurnObject(request);

                var turnCreated = await _turnRepository.CreateTurnAsync(turn);

                var result = _mapper.Map<CreateTurnResult>(turnCreated);

                return Created("Turn created.", result);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("GetTurn/{turnId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<CreateTurnResult>> GetTurn(int turnId)
        {
            try
            {
                Turn turn = await _turnRepository.GetTurnByIdAsync(turnId);

                if (turn is null)
                {
                    return NotFound("Turn not found.");
                }

                var result = _mapper.Map<CreateTurnResult>(turn);

                return Ok(result);
            }
            catch (Exception)
            {

                throw;
            }
        }
        private static Turn SetTurnObject(CreateTurnCommand turn)
        {
            return new Turn
            {
                Description = turn.Description,
                StartTime = turn.StartTime,
                EndTime = turn.EndTime
            };
        }
    }
}
