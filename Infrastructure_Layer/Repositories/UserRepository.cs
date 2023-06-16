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
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public UserRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> CreateUserAsync(User user)
        {
            await _dbContext.Users.AddAsync(user);
            
            await _dbContext.SaveChangesAsync();

            return user;
        }

        public async Task<Beautician> GetBeauticianAsync(int beauticianId)
        {
            return await _dbContext.Beauticians
                         .Where(c => c.PersonId == beauticianId)
                         .FirstOrDefaultAsync();
        }

        public async Task<Client> GetClientAsync(int clientId)
        {
            return await _dbContext.Clients
                         .Where(c => c.PersonId == clientId)
                         .FirstOrDefaultAsync();
        }
    }
}
