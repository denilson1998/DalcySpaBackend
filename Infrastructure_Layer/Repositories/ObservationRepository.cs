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
    public class ObservationRepository : IObservationRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public ObservationRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Observation> CreateObservationAsync(Observation observation)
        {
            await _dbContext.Observations.AddAsync(observation);

            await _dbContext.SaveChangesAsync();

            return observation;
        }

        public async Task<List<Observation>> GetObservations(int appointmentId)
        {
            return await _dbContext.Observations
                         .Where(o => o.AppointmentId == appointmentId)
                         .ToListAsync();
        }
    }
}
