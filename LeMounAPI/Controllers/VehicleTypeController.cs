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

        public async Task<ActionResult<VehicleTypeModel>> GetAll()
        {
            var result = await _modelService.GetAll();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VehicleTypeModel>> Get(long id)
        {

            var result = await _modelService.Get(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<VehicleTypeModel>> CreateUser(VehicleTypeModel vehicleTypeModel)
        {
            await _modelService.Add(vehicleTypeModel);
            return Ok(vehicleTypeModel);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<VehicleTypeModel>> UpdateUser(long id, [FromBody] VehicleTypeModel updatedVehicleType)
        {
            var result = await _modelService.Update(id, updatedVehicleType);

            return result;
        }

        //Right now the Delete returns a 500 internal error if user not found NEEDS fixing 

        [HttpDelete("{id}")]
        public async Task<ActionResult<VehicleTypeModel>> DeleteOrderById(long id)
        {

            await _modelService.Delete(id);

            return Ok($"Order Deleted, user id: {id}");
        }
    }
}
