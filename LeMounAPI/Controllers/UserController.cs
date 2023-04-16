using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LeMounAPI.Models;
namespace LeMounAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private static List<User> Users = new List<User>
            {
                new User
                {   UserId = 1,
                    Email = "test",
                    Password = "1234",
                    StatusId = 1,
                    RoleId = 1
                }
            };
        [HttpGet]
        // Not using the IActionResult interface will allow us to show an Example Value in Swagger.

        public async Task<ActionResult<User>> GetAll()
        {
            return Ok(Users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(long id)
        {
            //var user = Users.FirstOrDefault(x => x.UserId == id);

            //return Ok(user);

            var user = Users.FirstOrDefault(x => x.UserId == id);

            if (user == null)
            {
                return BadRequest("User not found");
            }

            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<User>> CreateUser(User user)
        {
            Users.Add(user);

            return Ok(Users);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<User>> UpdateUser(long id, User updatedUser)
        {
            var user = Users.FirstOrDefault(x => x.UserId == id);

            if (user == null)
            {
                return BadRequest("user not found");
            }
            else
            {
                user.UserId = updatedUser.UserId;
                user.Email = updatedUser.Email;
                user.Password = updatedUser.Password;
                user.RoleId = updatedUser.RoleId;
                user.StatusId = updatedUser.StatusId;

                return Ok(user);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUserById(long id)
        {
            var user = Users.FirstOrDefault(x => x.UserId == id);

            if (user == null)
            {
                return BadRequest();
            }

            Users.Remove(user);
            return Ok("User deleted");
        }
    }
}
