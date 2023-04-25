using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LeMounAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserStatusController : ControllerBase
    {
        private readonly IModelRepository<UserStatusModel> _modelService;

        public UserStatusController(IModelRepository<UserStatusModel> modelService)
        {
            _modelService = modelService;
        }

        [HttpGet]
        // Not using the IActionResult interface will allow us to show an Example Value in Swagger.

        // Get all
        public async Task<ActionResult<UserStatusModel>> GetAll()
        {
            var result = await _modelService.GetAll();

            return Ok(result);
        }

        // Get by Id
        [HttpGet("{id}")]
        public async Task<ActionResult<UserStatusModel>> Get(long id)
        {

            var result = await _modelService.Get(id);
            return Ok(result);
        }

        // Create UserStatus
        [HttpPost]
        public async Task<ActionResult<UserStatusModel>> CreateUserStatus(UserStatusModel userStatus)
        {
            await _modelService.Add(userStatus);
            return Ok(userStatus);
        }

        // Update by id
        [HttpPut("{id}")]
        public async Task<ActionResult<UserStatusModel>> UpdateUserStatus(long id, [FromBody] UserStatusModel updatedStatus)
        {
            var result = await _modelService.Update(id, updatedStatus);

            return result;
        }

        // Delete by id 
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserStatusModel>> DeleteUserStatusById(long id)
        {

            await _modelService.Delete(id);

            return Ok($"Order Deleted, user id: {id}");
        }
    }
}
