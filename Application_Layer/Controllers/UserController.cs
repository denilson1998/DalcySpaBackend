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
        public async Task<ActionResult<UserResult>> CreateUser(UserCommand request)
        {
            try
            {

                User user = SetUserObject(request);

                var userCreated = await _userRepository.CreateUserAsync(user);

                if (userCreated is null) 
                {
                    return BadRequest("User not Created!");
                }

                Person person = SetPersonObject(request, userCreated.Id);

                var personCreated = await _personRepository.CreatePersonAsync(person);

                var typeOfPerson = SetTypeOfPersonObject(request.RoleId);

                if (typeOfPerson is Beautician)
                {
                    await _personRepository.CreateBeauticianAsync((Beautician)typeOfPerson);
                }
                else
                {
                    await _personRepository.CreateClientAsync((Client)typeOfPerson);
                }

                var response = _mapper.Map<UserResult>(userCreated);

                return Created("User created!", response);
            }
            catch (Exception exc)
            {

                throw new Exception(exc.Message);
            }
        }

        private static User SetUserObject(UserCommand user)
        {
            return new User
            {
                Email = user.Email,
                Password = user.Password,
                Role = (Roles)user.RoleId
            };
        } 

        private static Person SetPersonObject(UserCommand person, int UserId)
        {
            return new Person
            {
                CellphoneNumber = person.CellphoneNumber,
                Ci = person.Ci,
                LastName = person.LastName,
                Name = person.Name,
                UserId = UserId
            };
        }

        private static Person SetTypeOfPersonObject(int RoleId)
        {
            if ((Roles)RoleId is Roles.Client)
            {
                return new Client
                {
                    PersonId = RoleId
                };
            }

            return new Beautician
            {
                PersonId = RoleId
            };

        }
    }
}
