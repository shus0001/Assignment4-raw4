using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _2._Data_Layer_Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace _1._Northwind_API.Controllers
{
    public class CategoryController : ControllerBase
    {
        private ICategoryRepository categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        [HttpGet]
        [Route("api/Category")]
        public ActionResult GetAllCategories()
        {
            return Ok(categoryRepository.GetAll());
        }
    }
}