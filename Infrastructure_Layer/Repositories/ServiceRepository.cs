using Domain_Layer.Entities;
using Domain_Layer.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure_Layer.Repositories
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public ServiceRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Service> CreateServiceAsync(Service service)
        {
            await _dbContext.Services.AddAsync(service);

            await _dbContext.SaveChangesAsync();

            return service;
        }

        public async Task<List<Service>> GetServicesByCategoryId(int categoryId)
        {
            return await _dbContext.Services
                .Where(s => s.CategoryId == categoryId)
                .ToListAsync();
        }

        public async Task<Service> GetServiceByIdAsync(int serviceId)
        {
            return await _dbContext.Services
                        .Where(s => s.Id == serviceId)
                        .FirstOrDefaultAsync();
        }
    }
}
