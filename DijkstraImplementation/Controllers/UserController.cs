using DijkstraImplementation.Data;
using DijkstraImplementation.Models.DTOs.UserDTOs;
using DijkstraImplementation.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DijkstraImplementation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UsersController : ControllerBase
    {
        private readonly AppDbContext dbContext;

        public UsersController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var allUsers = dbContext.Users.ToList();
            return Ok(allUsers);
        }

        [HttpGet]
        [Route("{Username:regex([[A-Za-z0-9!@#$%^&*()-_=+]])}")]
        public IActionResult getUserByUsername(string Username)
        {
            var user = dbContext.Users.Find(Username);
            if (user is null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public IActionResult AddUser(AddUserDto addUserDto)
        {
            if (ModelState.IsValid)
            {
                var userEntity = new User()
                {
                    UserId = addUserDto.UserId,
                    Name = addUserDto.Name,
                    Username = addUserDto.Username,
                    Password = addUserDto.Password,
                };

                dbContext.Users.Add(userEntity);
                dbContext.SaveChanges();
                return Ok(userEntity);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut]
        [Route("{Username:regex([[A-Za-z0-9!@#$%^&*()-_=+]])}")]
        public IActionResult UpdateUser(string Username, UpdateUserDto updateUserDto)
        {
            var user = dbContext.Users.Find(Username);
            if (ModelState.IsValid)
            {
                user.Password = updateUserDto.Password;
                dbContext.SaveChanges();
                return Ok(user);

            }
            else 
            {
                return BadRequest(ModelState);
            }
            
            

        }

        [HttpDelete]
        [Route("{Username:regex([[A-Za-z0-9!@#$%^&*()-_=+]])}")]
        public IActionResult DeleteUser(string Username)
        {
            var user = dbContext.Users.Find(Username);
            if (user is null)
            {
                return NotFound();
            }
            dbContext.Users.Remove(user);
            dbContext.SaveChanges();
            return Ok();
        }
    }
}
