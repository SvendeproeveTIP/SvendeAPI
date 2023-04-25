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
        private readonly IModelRepository<UserModel> _modelService;

        public UserController(IModelRepository<UserModel> modelService)
        {
            _modelService = modelService;
        }

        [HttpGet]
        // Not using the IActionResult interface will allow us to show an Example Value in Swagger.

        // Get all 
        public async Task<ActionResult<UserModel>> GetAll()
        {
            var result = await _modelService.GetAll();

            return Ok(result);
        }

        // Get by Id
        [HttpGet("{id}")]
        public async Task<ActionResult<UserModel>> Get(long id)
        {
            var result = await _modelService.Get(id);
            return Ok(result);
        }

        // Create User
        [HttpPost]
        public async Task<ActionResult<UserModel>> CreateUser([FromBody]UserModel user)
        {
            return Ok(await _modelService.Add(user));
        }

        // Update by Id
        [HttpPut("{id}")]
        public async Task<ActionResult<UserModel>> UpdateUser(long id, [FromBody] UserModel updatedUser)
        {
            var result = await _modelService.Update(id, updatedUser);

            return result;
        }

        // Delete by Id
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserModel>> DeleteUserById(long id)
        {
            
            await _modelService.Delete(id);

            return Ok($"User Deleted, user id: {id}");
        }
    }
}
