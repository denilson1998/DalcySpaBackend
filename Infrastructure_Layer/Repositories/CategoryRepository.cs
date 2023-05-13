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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CategoryRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Category> CreateCategoryAsync(Category category)
        {
            await _dbContext.Categories.AddAsync(category);
            
            await _dbContext.SaveChangesAsync();

            return category;
        }

        public async Task<List<Category>> GetAllCategories()
        {
            return await _dbContext.Categories.ToListAsync();
        }
    }
}
