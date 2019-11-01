using _1._Northwind_API.Models;
using _2._Data_Layer_Abstraction;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _1._Northwind_API.Controllers
{
    public class CategoriesController : ControllerBase
    {
        private ICategoryRepository categoryRepository;
        public CategoriesController(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        [HttpGet]
        [Route("api/categories")]
        public ActionResult GetAllCategories()
        {
            return Ok(categoryRepository.GetAll());
        }
    }
}
