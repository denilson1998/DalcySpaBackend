using AutoMapper;
using Domain_Layer.Entities;
using Domain_Layer.Models.Command;
using Domain_Layer.Models.Result;
using Domain_Layer.Persistence.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Application_Layer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryController(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        [HttpPost("CreateCategory")]
        public async Task<ActionResult<CreateCategoryResult>> CreateCategory(CreateCategoryCommand request)
        {
            try
            {
                Category category = SetCategoryObject(request);

                var categoryCreated = await _categoryRepository.CreateCategoryAsync(category);

                var result = _mapper.Map<CreateCategoryResult>(categoryCreated);

                return Created("Category created", result);
                
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("ListCategories")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<List<CreateCategoryResult>>> ListCategories()
        {
            try
            {
                var categories = await _categoryRepository.GetAllCategories();

                if (categories is null)
                {
                    return NotFound("There are no categories.");
                }

                var result = _mapper.Map<List<CreateCategoryResult>>(categories);

                return Ok(result);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("GetCategory/{categoryId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<CreateCategoryResult>> GetCategory(int categoryId)
        {
            try
            {
                var category= await _categoryRepository.GetCategoryByIdAsync(categoryId);

                if (category is null)
                {
                    return NotFound("Category not found.");
                }

                var result = _mapper.Map<CreateCategoryResult>(category);

                return Ok(result);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private static Category SetCategoryObject(CreateCategoryCommand category)
        {
            return new Category
            {
               Description = category.Description
            };
        }
    }
}
