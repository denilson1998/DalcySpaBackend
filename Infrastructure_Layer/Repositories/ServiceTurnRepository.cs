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
    public class ServiceTurnRepository : IServiceTurnRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public ServiceTurnRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ServiceTurn> CreateServiceTurnAsync(ServiceTurn serviceTurn)
        {
            await _dbContext.ServicesTurns.AddAsync(serviceTurn);

            await _dbContext.SaveChangesAsync();

            return serviceTurn;
        }

        public async Task<ServiceTurn> GetServiceTurnAsync(int serviceId, int turnId)
        {
            return await _dbContext.ServicesTurns
                          .Where(st => st.ServiceId == serviceId && st.TurnId == turnId)
                          .FirstOrDefaultAsync();
        }

        public async Task<List<ServiceTurn>> GetTurnsOfService(int serviceId)
        {
            return await _dbContext.ServicesTurns
                         .Where(st => st.ServiceId == serviceId)
                         .ToListAsync();
        }
    }
}
