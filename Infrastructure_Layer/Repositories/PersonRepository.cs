using Domain_Layer.Entities;
using Domain_Layer.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure_Layer.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public PersonRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Person> CreatePersonAsync(Person person)
        {
            await _dbContext.People.AddAsync(person);

            await _dbContext.SaveChangesAsync();

            return person;
        }

        public async Task<Beautician> CreateBeauticianAsync(Beautician beautician)
        {
            await _dbContext.Beauticians.AddAsync(beautician);

            await _dbContext.SaveChangesAsync();

            return beautician;
        }

        public async Task<Client> CreateClientAsync(Client client)
        {
            await _dbContext.Clients.AddAsync(client);

            await _dbContext.SaveChangesAsync();

            return client;
        }
    }
}
