using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserService.Data;
using UserService.Dtos;
using UserService.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepo repository;
        private readonly IMapper mapper;

        public UserController(IUserRepo repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<UserReadDto>> GetUsers()
        {
            Console.WriteLine("--> Getting Users...");

            var userItem = repository.GetAllUsers();

            return Ok(mapper.Map<IEnumerable<UserReadDto>>(userItem));
        }

        [HttpGet("{id}", Name = "GetUserById")]
        public ActionResult<UserReadDto> GetUserById(int id)
        {
            Console.WriteLine("--> Getting User by ID...");

            var userItem = repository.GetUserById(id);
            if (userItem != null)
            {
                return Ok(mapper.Map<UserReadDto>(userItem));
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult<UserReadDto> CreateUser(UserCreateDto userCreateDto)
        {
            Console.WriteLine("--> Creating User...");

            var userModel = mapper.Map<User>(userCreateDto);
            try
            {
                repository.CreateUser(userModel);
                repository.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"--> Could not send synchronously: {ex.Message}");
            }            

            var userItem = mapper.Map<UserReadDto>(userModel);

            return CreatedAtRoute(nameof(GetUserById), new { userItem.Id }, userItem);
        }

    }
}
