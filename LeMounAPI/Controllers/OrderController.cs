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
        private readonly IModelService<OrderModel> _modelService;

        public OrderController(IModelService<OrderModel> modelService)
        {
            _modelService = modelService;
        }

        [HttpGet]
        // Not using the IActionResult interface will allow us to show an Example Value in Swagger.

        public async Task<ActionResult<OrderModel>> GetAll()
        {
            var result = await _modelService.GetAll();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderModel>> Get(long id)
        {

            var result =  _modelService.Get(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<OrderModel>> CreateUser(OrderModel order)
        {
            await _modelService.Add(order);
            return Ok(order);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<OrderModel>> UpdateUser(long id, [FromBody] OrderModel updatedOrder)
        {
            var result = await _modelService.Update(id, updatedOrder);

            return result;
        }

        //Right now the Delete returns a 500 internal error if user not found NEEDS fixing 

        [HttpDelete("{id}")]
        public async Task<ActionResult<OrderModel>> DeleteOrderById(long id)
        {

            await _modelService.Delete(id);

            return Ok($"Order Deleted, user id: {id}");
        }

    }
}
