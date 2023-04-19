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
        private readonly IModelService<UserStatusModel> _modelService;

        public UserStatusController(IModelService<UserStatusModel> modelService)
        {
            _modelService = modelService;
        }

        [HttpGet]
        // Not using the IActionResult interface will allow us to show an Example Value in Swagger.

        public async Task<ActionResult<UserStatusModel>> GetAll()
        {
            var result = await _modelService.GetAll();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserStatusModel>> Get(long id)
        {

            var result = await _modelService.Get(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<UserStatusModel>> CreateUser(UserStatusModel userStatus)
        {
            await _modelService.Add(userStatus);
            return Ok(userStatus);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserStatusModel>> UpdateUser(long id, [FromBody] UserStatusModel updatedStatus)
        {
            var result = await _modelService.Update(id, updatedStatus);

            return result;
        }

        //Right now the Delete returns a 500 internal error if user not found NEEDS fixing 

        [HttpDelete("{id}")]
        public async Task<ActionResult<UserStatusModel>> DeleteOrderById(long id)
        {

            await _modelService.Delete(id);

            return Ok($"Order Deleted, user id: {id}");
        }
    }
}
