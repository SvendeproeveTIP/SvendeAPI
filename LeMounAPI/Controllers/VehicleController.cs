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
    public class VehicleController : ControllerBase
    {
        private readonly IModelRepository<VehicleModel> _modelService;

        public VehicleController(IModelRepository<VehicleModel> modelService)
        {
            _modelService = modelService;
        }

        [HttpGet]
        // Not using the IActionResult interface will allow us to show an Example Value in Swagger.

        public async Task<ActionResult<VehicleModel>> GetAll()
        {
            var result = await _modelService.GetAll();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VehicleModel>> Get(long id)
        {

            var result = await _modelService.Get(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<VehicleModel>> CreateUser(VehicleModel vehicleModel)
        {
            await _modelService.Add(vehicleModel);
            return Ok(vehicleModel);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<VehicleModel>> UpdateUser(long id, [FromBody] VehicleModel updatedVehicle)
        {
            var result = await _modelService.Update(id, updatedVehicle);

            return result;
        }

        //Right now the Delete returns a 500 internal error if user not found NEEDS fixing 

        [HttpDelete("{id}")]
        public async Task<ActionResult<VehicleModel>> DeleteOrderById(long id)
        {

            await _modelService.Delete(id);

            return Ok($"Order Deleted, user id: {id}");
        }
    }
}
