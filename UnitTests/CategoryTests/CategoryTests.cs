using Application_Layer.Controllers;
using AutoMapper;
using Domain_Layer.Entities;
using Domain_Layer.Models.Command;
using Domain_Layer.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.CategoryTests
{
    public class CategoryTests
    {
        [Fact]
        public async void GetCategory()
        {
            var categoryId = 1;
            var categoryRepository = new Mock<ICategoryRepository>();
            var mapper = new Mock<IMapper>();

            categoryRepository.Setup(repo => repo.GetCategoryByIdAsync(categoryId))
                .ReturnsAsync(new Category
                {
                    Id = categoryId,
                    Description = ""
                });

            var getController = new CategoryController(
                categoryRepository.Object,
                mapper.Object);

            var result = await getController.GetCategory(categoryId);

            Assert.IsTrue(result.Result is OkObjectResult);
        }

        [Fact]
        public async void CreateCategory()
        {
            var categoryRepository = new Mock<ICategoryRepository>();
            var mapper = new Mock<IMapper>();

            var getController = new CategoryController(
                categoryRepository.Object,
                mapper.Object);

            var request = new CreateCategoryCommand
            {
                Description = "Test Category"
            };

            var result = await getController.CreateCategory(request);
            Assert.IsTrue(result.Result is OkObjectResult);
        }
    }
}
