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
    public class UserRoleController : ControllerBase
    {
        private readonly IModelRepository<UserRoleModel> _modelService;

        public UserRoleController(IModelRepository<UserRoleModel> modelService)
        {
            _modelService = modelService;
        }

        [HttpGet]
        // Not using the IActionResult interface will allow us to show an Example Value in Swagger.

        public async Task<ActionResult<UserRoleModel>> GetAll()
        {
            var result = await _modelService.GetAll();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserRoleModel>> Get(long id)
        {

            var result = await _modelService.Get(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<UserRoleModel>> CreateUser(UserRoleModel userRole)
        {
            await _modelService.Add(userRole);
            return Ok(userRole);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserRoleModel>> UpdateUser(long id, [FromBody] UserRoleModel updatedRole)
        {
            var result = await _modelService.Update(id, updatedRole);

            return result;
        }

        //Right now the Delete returns a 500 internal error if user not found NEEDS fixing 

        [HttpDelete("{id}")]
        public async Task<ActionResult<UserRoleModel>> DeleteOrderById(long id)
        {

            await _modelService.Delete(id);

            return Ok($"Order Deleted, user id: {id}");
        }
    }
}
