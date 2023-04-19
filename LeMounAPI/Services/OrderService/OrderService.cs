using System;
using AutoMapper.QueryableExtensions;

namespace LeMounAPI.Services.OrderService
{
    public class OrderService : IModelService<OrderModel>
    {
        // Creating a reference to Data context and IMapper
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        // Creating a constructor, that initializez the context and mapper.
        public OrderService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // Gets list of all users and maps them out to the models.
        public async Task<List<OrderModel>> GetAll()
        {
            var orders = await _context.Orders
                .ProjectTo<OrderModel>(_mapper.ConfigurationProvider).ToListAsync();

            return orders;
        }

        // Gets user by an Id and returns a UserModel that is mapped to a User entity.
        public async Task<OrderModel> Get(long id)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(x => x.OrderId == id);

            if (order is null)
            {
                throw new IdNotFoundException(id);
            }

            return _mapper.Map<OrderModel>(order);
        }

        // Creates an UserModel and returns it.
        public async Task<OrderModel> Add(OrderModel order)
        {
            var Order = new Order(order.OrderDate, order.OrderEnded, order.Price, order.UserId, order.VehicleId);
            await _context.Orders.AddAsync(Order);
            _context.SaveChanges();

            return order;
        }

        // Finds the first user that has the same id as the argument it takes, if found it updates the UserModel with the same data as fed.
        // Otherwise throws and exception.
        // Returns an Entity that is mapped out to the model. reason for this is to return only the needed data and not all sensitive data.
        public async Task<OrderModel> Update(long id, OrderModel updatedOrder)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(x => x.UserId == id);

            if (order is null)
            {
                throw new IdNotFoundException(id);
            }
            else
            {
                order.EndDate = updatedOrder.EndDate;
                order.OrderDate = updatedOrder.OrderDate;
                order.OrderEnded = updatedOrder.OrderEnded;
                order.Price = updatedOrder.Price;
            }

            _context.Orders.Update(order);
            _context.SaveChanges();

            return _mapper.Map<OrderModel>(order);
        }

        // Finds the first user that has the same id as the argument it takes, if found removes the user, if not throws exception.
        public async Task Delete(long id)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(x => x.OrderId == id);

            if (order is null)
            {
                throw new IdNotFoundException(id);
            }

            _context.Orders.Remove(order);
            _context.SaveChanges();
        }
    }
}

