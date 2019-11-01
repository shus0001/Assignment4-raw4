using _0._Models;
using _1._Northwind_API.Models;
using _2._Data_Layer_Abstraction;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace _1._Northwind_API.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController
    {
        private IProductRepository productRepository;
        private IMapper mapper;

        public ProductsController(IProductRepository productRepository, IMapper mapper)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
        }

        [HttpGet(Name = nameof(GetProducts))]
        public ActionResult GetProducts()
        {
            var products = productRepository.GetAll();

            return Ok(products);
        }

        [HttpGet("{productId}", Name = nameof(GetProduct))]
        public ActionResult GetProduct(int productId)
        {
            var category = productRepository.GetById(productId);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(CreateProductDto(category));
        }

        ///////////////////
        //
        // Helpers
        //
        //////////////////////

        private ProductDto CreateProductDto(Product product)
        {
            var dto = mapper.Map<ProductDto>(product);
            dto.Link = Url.Link(
                nameof(GetProduct),
                new { productId = product.Id });
            return dto;
        }

        private IEnumerable<ProductDto> CreateResult(IEnumerable<Product> products)
        {
            return products.Select(p => CreateProductDto(p));
        }
    }
}