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

        // Get all
        public async Task<ActionResult<VehicleModel>> GetAll()
        {
            var result = await _modelService.GetAll();

            return Ok(result);
        }

        // Get by id 
        [HttpGet("{id}")]
        public async Task<ActionResult<VehicleModel>> Get(long id)
        {

            var result = await _modelService.Get(id);
            return Ok(result);
        }

        // Create Vehicle
        [HttpPost]
        public async Task<ActionResult<VehicleModel>> CreateVehicle(VehicleModel vehicleModel)
        {
            await _modelService.Add(vehicleModel);
            return Ok(vehicleModel);
        }

        // Update by id
        [HttpPut("{id}")]
        public async Task<ActionResult<VehicleModel>> UpdateVehicle(long id, [FromBody] VehicleModel updatedVehicle)
        {
            var result = await _modelService.Update(id, updatedVehicle);

            return result;
        }

        // Delete by id
        [HttpDelete("{id}")]
        public async Task<ActionResult<VehicleModel>> DeleteVehicleById(long id)
        {

            await _modelService.Delete(id);

            return Ok($"Order Deleted, user id: {id}");
        }
    }
}
