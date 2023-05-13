using Domain_Layer.Entities;
using Domain_Layer.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure_Layer.Repositories
{
    public class TurnRepository : ITurnRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public TurnRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Turn> CreateTurnAsync(Turn turn)
        {
            await _dbContext.Turns.AddAsync(turn);

            await _dbContext.SaveChangesAsync();

            return turn;
        }
    }
}
