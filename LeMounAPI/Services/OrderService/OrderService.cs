using System;

namespace LeMounAPI.Services.OrderService
{
    public class OrderService : IModelService<Order>
    {
        private List<Order> Orders = new List<Order>
        {
            new Order
            {
                OrderId = 1,
                OrderDate = DateTime.Now,
                OrderEnded = false,
                EndDate = DateTime.Now.AddHours(2),
                UserId = 1,
                VehicleId = 1
            },
            new Order
            {
                OrderId = 2,
                OrderDate = DateTime.Now,
                OrderEnded = false,
                EndDate = DateTime.Now.AddHours(1),
                UserId = 2,
                VehicleId = 2
            }
        };

        public void Add(Order order)
        {
            Orders.Add(order);
        }

        public void Delete(long id)
        {
            var order = Orders.FirstOrDefault(x => x.OrderId == id);

            if (order is null)
            {
                throw new IdNotFoundException(id);
            }
        }

        public Order Get(long id)
        {
            var order = Orders.FirstOrDefault(x => x.OrderId == id);

            if (order is null)
            {
                throw new IdNotFoundException(id);
            }

            return order;
        }

        public List<Order> GetAll()
        {
            return Orders;
        }

        // This needs to get updated and fixed, because right now you are able to update the whole order.

        public Order Update(long id, Order updatedOrder)
        {
            var order = Orders.FirstOrDefault(x => x.OrderId == id);

            if (order is null)
            {
                throw new IdNotFoundException(id);
            }

            order = updatedOrder;

            return order;
        }
    }
}

