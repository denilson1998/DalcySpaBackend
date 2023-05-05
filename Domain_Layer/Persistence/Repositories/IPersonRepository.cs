using Domain_Layer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Layer.Persistence.Repositories
{
    public interface IPersonRepository
    {
        public Task<Person> CreatePersonAsync(Person person);

        public Task<Client> CreateClientAsync(Client client);

        public Task<Beautician> CreateBeauticianAsync(Beautician beautician);
    }
}
