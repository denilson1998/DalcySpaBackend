using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain_Layer.Models.Command;
using Domain_Layer.Models.Result;
using Domain_Layer.Entities;
using Domain_Layer.Persistence.Repositories;

namespace Application_Layer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(IMapper mapper, ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        [HttpPost("CreateCategory")]
        public async Task<ActionResult<CategoryResult>> CreateCategory(CategoryCommand command)
        {
            try
            {
                Category category = SetCategoryObject(command);

                var categoryCreated = await _categoryRepository.CreateCategoryAsync(category);

                var result = _mapper.Map<CategoryResult>(categoryCreated);

                return Created("Category Created", result);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        [HttpGet("GetCategoryById/{CategoryId}")]
        public async Task<ActionResult<CategoryResult>> GetCategoryById(int CategoryId)
        {
            try
            {
                Category category = await _categoryRepository.GetCategoryById(CategoryId);

                if (category is null)
                {
                    return BadRequest("Category not found");
                }

                var result = _mapper.Map<CategoryResult>(category);

                return Ok(result);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        private static Category SetCategoryObject(CategoryCommand category)
        {
            return new Category
            {
                Description = category.Description
            };
        }
    }
}
