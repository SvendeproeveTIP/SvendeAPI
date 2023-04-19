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
        private readonly IModelService<UserModel> _modelService;

        public UserController(IModelService<UserModel> modelService)
        {
            _modelService = modelService;
        }

        [HttpGet]
        // Not using the IActionResult interface will allow us to show an Example Value in Swagger.

        public async Task<ActionResult<UserModel>> GetAll()
        {
            var result = await _modelService.GetAll();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserModel>> Get(long id)
        {
            var result = await _modelService.Get(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<UserModel>> CreateUser(UserModel user)
        {
            await _modelService.Add(user);
            return Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserModel>> UpdateUser(long id, [FromBody] UserModel updatedUser)
        {
            var result = await _modelService.Update(id, updatedUser);

            return result;
        }

        //Right now the Delete returns a 500 internal error if user not found NEEDS fixing 

        [HttpDelete("{id}")]
        public async Task<ActionResult<UserModel>> DeleteUserById(long id)
        {
            
            await _modelService.Delete(id);

            return Ok($"User Deleted, user id: {id}");
        }
    }
}
