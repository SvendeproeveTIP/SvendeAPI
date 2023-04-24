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
    public class VehicleTypeController : ControllerBase
    {
        private readonly IModelRepository<VehicleTypeModel> _modelService;

        public VehicleTypeController(IModelRepository<VehicleTypeModel> modelService)
        {
            _modelService = modelService;
        }

        [HttpGet]
        // Not using the IActionResult interface will allow us to show an Example Value in Swagger.

        // Get All
        public async Task<ActionResult<VehicleTypeModel>> GetAll()
        {
            var result = await _modelService.GetAll();

            return Ok(result);
        }

        // Get By Id
        [HttpGet("{id}")]
        public async Task<ActionResult<VehicleTypeModel>> Get(long id)
        {

            var result = await _modelService.Get(id);
            return Ok(result);
        }

        // Create VehicleType
        [HttpPost]
        public async Task<ActionResult<VehicleTypeModel>> CreateVehicleType(VehicleTypeModel vehicleTypeModel)
        {
            await _modelService.Add(vehicleTypeModel);
            return Ok(vehicleTypeModel);
        }

        // Update by id
        [HttpPut("{id}")]
        public async Task<ActionResult<VehicleTypeModel>> UpdateVehicleType(long id, [FromBody] VehicleTypeModel updatedVehicleType)
        {
            var result = await _modelService.Update(id, updatedVehicleType);

            return result;
        }

        // Delete by id 
        [HttpDelete("{id}")]
        public async Task<ActionResult<VehicleTypeModel>> DeleteVehicleTypeById(long id)
        {

            await _modelService.Delete(id);

            return Ok($"Order Deleted, user id: {id}");
        }
    }
}
