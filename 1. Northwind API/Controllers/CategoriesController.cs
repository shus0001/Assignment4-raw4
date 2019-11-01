using _0._Models;
using _1._Northwind_API.Models;
using _2._Data_Layer_Abstraction;
using _3._Data_Layer;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _1._Northwind_API.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoriesController : ControllerBase
    {
        private ICategoryRepository categoryRepository;
        private IMapper mapper;
        public CategoriesController(ICategoryRepository categoryRepository, IMapper mapper)
        {
            this.categoryRepository = categoryRepository;
            this.mapper = mapper;
        }

        [HttpGet(Name = nameof(GetCategories))]
        public ActionResult GetCategories()
        {
            var categories = categoryRepository.GetAll();

            var result = CreateResult(categories);

            return Ok(result);
        }

        [HttpGet("{categoryId}", Name = nameof(GetCategory))]
        public ActionResult GetCategory(int categoryId)
        {
            var category = categoryRepository.GetById(categoryId);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(CreateCategoryDto(category));
        }

        ///////////////////
        //
        // Helpers
        //
        //////////////////////

        private CategoryDto CreateCategoryDto(Category category)
        {
            var dto = mapper.Map<CategoryDto>(category);
            dto.Link = Url.Link(
                    nameof(GetCategory),
                    new { categoryId = category.Id });
            return dto;
        }

        private object CreateResult(IEnumerable<Category> categories)
        {
            var totalItems = categoryRepository.NumberOfCategories();
            return new
            {
                totalItems,
                items = categories.Select(CreateCategoryDto)
            };
        }

        private string CreatePagingLink(int page, int pageSize)
        {
            return Url.Link(nameof(GetCategories), new { page, pageSize });
        }


    }
}
