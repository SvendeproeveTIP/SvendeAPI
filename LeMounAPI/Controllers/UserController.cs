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
        private readonly IModelService<User> _modelService;

        public UserController(IModelService<User> modelService)
        {
            _modelService = modelService;
        }

        [HttpGet]
        // Not using the IActionResult interface will allow us to show an Example Value in Swagger.

        public async Task<ActionResult<User>> GetAll()
        {
            var result = _modelService.GetAll();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(long id)
        {
            //var user = Users.FirstOrDefault(x => x.UserId == id);

            //return Ok(user);

            var result = _modelService.Get(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<User>> CreateUser(User user)
        {
            _modelService.Add(user);
            return Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<User>> UpdateUser(long id, [FromBody] User updatedUser)
        {
            var result = _modelService.Update(id, updatedUser);

            return result;
        }

        //Right now the Delete returns a 500 internal error if user not found NEEDS fixing 

        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUserById(long id)
        {
            
             _modelService.Delete(id);

            return Ok($"User Deleted, user id: {id}");
        }
    }
}
