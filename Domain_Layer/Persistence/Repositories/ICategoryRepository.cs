using Domain_Layer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Layer.Persistence.Repositories
{
    public interface ICategoryRepository
    {
        public Task<Category> CreateCategoryAsync(Category category);

        public Task<List<Category>> GetAllCategories();

        public Task<Category> GetCategoryByIdAsync(int categoryId);
    }
}
