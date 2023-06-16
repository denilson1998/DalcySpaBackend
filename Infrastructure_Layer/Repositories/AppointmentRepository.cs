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
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public AppointmentRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Appointment> CreateAppointmentAsync(Appointment appointment)
        {
            await _dbContext.Appointments.AddAsync(appointment);

            await _dbContext.SaveChangesAsync();

            return appointment;
        }

        public async Task<List<Appointment>> GetAppointmentsByBeauticianId(int beauticianId)
        {
            return await _dbContext.Appointments
                         .Where(a => a.BeauticianId == beauticianId)
                         .ToListAsync();
        }

        public async Task<List<Appointment>> GetAppointmentsByClientId(int clientId)
        {
            return await _dbContext.Appointments
                         .Where(c => c.ClientId == clientId)
                         .ToListAsync();
        }

        public async Task<Appointment> GetAppointmentByIdAsync(int appointmentId)
        {
            return await _dbContext.Appointments
                         .Where(a => a.Id == appointmentId)
                         .FirstOrDefaultAsync();
        }
    }
}
