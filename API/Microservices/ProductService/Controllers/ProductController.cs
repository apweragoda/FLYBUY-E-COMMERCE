using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductService.Data;
using ProductService.Dtos;
using ProductService.Models;
using ProductService.SyncDataServices.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepo repository;
        private readonly IMapper mapper;
        private readonly IUserDataClient userDataClient;

        public ProductController(IProductRepo repository, IMapper mapper, IUserDataClient userDataClient)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.userDataClient = userDataClient;
        }


        [HttpGet]
        public ActionResult<IEnumerable<ProductReadDto>> GetProducts()
        {
            Console.WriteLine("--> Getting Products...");

            var productItem = repository.GetAllProducts();

            return Ok(mapper.Map<IEnumerable<ProductReadDto>>(productItem));
        }

        [HttpGet("{id}", Name = "GetProductById")]
        public ActionResult<ProductReadDto> GetProductById(int id)
        {
            Console.WriteLine("--> Getting Product By ID...");

            var productItem = repository.GetProductById(id);

            if (productItem != null)
            {
                return Ok(mapper.Map<ProductReadDto>(productItem));
            }

            return NotFound();
        }

        [HttpGet("category/{category}", Name = "GetProductsByCategory")]
        public ActionResult<ProductReadDto> GetProductsByCategory(string category)
        {
            Console.WriteLine("--> Getting Product By Category...");

            var productItem = repository.GetProductsByCategory(category);

            if (productItem != null)
            {
                return Ok(mapper.Map<IEnumerable<ProductReadDto>>(productItem));
            }

            return NotFound();
        }


        [HttpPost]
        public async Task<ActionResult<ProductReadDto>> CreateProduct(ProductCreateDto productCreateDto)
        {
            var productModel = mapper.Map<Product>(productCreateDto);
            repository.CreateProduct(productModel);
            repository.SaveChanges();
            Console.WriteLine("--> Creating Product...");

            var productItem = mapper.Map<ProductReadDto>(productModel);

            try
            {
                await userDataClient.SendProductsToUser(productItem);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"--> Could not send synchronously: {ex.Message}");
            }

            return CreatedAtRoute(nameof(GetProductById), new { productItem.Id }, productItem);
        }
    }
}
