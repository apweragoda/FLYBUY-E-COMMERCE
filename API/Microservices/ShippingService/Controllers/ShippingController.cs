using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ShippingService.Data;
using ShippingService.Dtos;
using ShippingService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShippingService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShippingController : ControllerBase
    {
        private readonly IShippingRepo repository;
        private readonly IMapper mapper;

        public ShippingController(IShippingRepo repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ShippingReadDto>> Get()
        {
            Console.WriteLine("--> Getting Shipping Info...");

            var shippingItem = repository.GetAllShippingInfo();
            
            return Ok(mapper.Map<IEnumerable<ShippingReadDto>>(shippingItem));
        }


        [HttpPost]
        public ActionResult<ShippingReadDto> CreateShipping(ShippingCreateDto shippingCreateDto)
        {
            Console.WriteLine("--> Creating Shipping Info...");

            var shippingModel = mapper.Map<Shipping>(shippingCreateDto);
            repository.CreateShippingInfo(shippingModel);
            repository.SaveChanges();

            var shippingItem = mapper.Map<ShippingReadDto>(shippingModel);

            return shippingItem;
        }

        
    }
}
