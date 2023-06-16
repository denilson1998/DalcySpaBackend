using Domain_Layer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Layer.Persistence.Repositories
{
    public interface IServiceRepository
    {
        public Task<Service> CreateServiceAsync(Service service);

        public Task<List<Service>> GetServicesByCategoryId(int categoryId);

        public Task<Service> GetServiceByIdAsync(int serviceId);
    }
}
