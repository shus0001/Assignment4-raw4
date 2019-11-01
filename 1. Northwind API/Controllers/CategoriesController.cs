﻿using _0._Models;
using _1._Northwind_API.Models;
using _2._Data_Layer_Abstraction;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

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

        private IEnumerable<CategoryDto> CreateResult(IEnumerable<Category> categories)
        {
            return categories.Select(c => CreateCategoryDto(c));
        }

    }
}
