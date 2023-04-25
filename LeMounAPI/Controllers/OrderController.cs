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
    public class OrderController : ControllerBase
    {
        private readonly IModelRepository<OrderModel> _modelService;

        public OrderController(IModelRepository<OrderModel> modelService)
        {
            _modelService = modelService;
        }

        [HttpGet]
        // Not using the IActionResult interface will allow us to show an Example Value in Swagger.

        // Get all 
        public async Task<ActionResult<OrderModel>> GetAll()
        {
            var result = await _modelService.GetAll();

            return Ok(result);
        }

        // Get by Id
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderModel>> Get(long id)
        {

            var result =  await _modelService.Get(id);
            return Ok(result);
        }

        // Create order
        [HttpPost]
        public async Task<ActionResult<OrderModel>> CreateOrder(OrderModel order)
        {
            await _modelService.Add(order);
            return Ok(order);
        }

        // Update by Id
        [HttpPut("{id}")]
        public async Task<ActionResult<OrderModel>> UpdateOrder(long id, [FromBody] OrderModel updatedOrder)
        {
            var result = await _modelService.Update(id, updatedOrder);

            return result;
        }


        // Delete by id
        [HttpDelete("{id}")]
        public async Task<ActionResult<OrderModel>> DeleteOrderById(long id)
        {

            await _modelService.Delete(id);

            return Ok($"Order Deleted, user id: {id}");
        }

    }
}
