using AutoMapper;
using Domain_Layer.Models.Result;
using Domain_Layer.Models.Command;
using Domain_Layer.Persistence.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain_Layer.Entities;
using System;

namespace Application_Layer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IPersonRepository _personRepository;
        public UserController(IMapper mapper, IUserRepository userRepository, IPersonRepository personRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _personRepository = personRepository;
        }

        [HttpPost("CreateUser")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<CreateUserResult>> CreateUser(CreateUserCommand request)
        {
            try
            {
                Person person = SetPersonObject(request);

                var personCreated = await _personRepository.CreatePersonAsync(person);

                if (personCreated is null)
                {
                    return BadRequest("Person not Created!");
                }

                if (request.RoleId == (int)Roles.Beautician)
                {
                    Beautician beautician = SetBeauticianObject(personCreated.Id);

                    await _personRepository.CreateBeauticianAsync(beautician);
                }
                else
                {
                    Client client = SetClientObject(personCreated.Id);

                    await _personRepository.CreateClientAsync(client);
                }

                User user = SetUserObject(request, personCreated.Id);

                var userCreated = await _userRepository.CreateUserAsync(user);

                var result = _mapper.Map<CreateUserResult>(userCreated);

                return Created("User created!", result);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private static User SetUserObject(CreateUserCommand user, int personId)
        {
            return new User
            {
                Email = user.Email,
                Password = user.Password,
                RoleId = (Roles)user.RoleId,
                PersonId = personId
            };
        } 

        private static Person SetPersonObject(CreateUserCommand person)
        {
            return new Person
            {
                CellphoneNumber = person.CellphoneNumber,
                Ci = person.Ci,
                LastName = person.LastName,
                Name = person.Name
            };
        }

        private static Client SetClientObject(int personId)
        {
            
            return new Client
            {
                PersonId = personId
            };

        }

        private static Beautician SetBeauticianObject(int personId)
        {
            return new Beautician
            {
                PersonId = personId
            };
        }
    }
}
