using System;
using LeMounAPI.Repositories.CustomExceptions;

namespace LeMounAPI.Repositories.VehicleRepository
{
	public class VehicleRepository : IModelRepository<VehicleModel>
	{
        // Creating a reference to Data context and IMapper
        private readonly DataContext _dataContext;
		private readonly IMapper _mapper;

        // Creating a constructor, that initializez the context and mapper.
        public VehicleRepository(DataContext dataContext, IMapper mapper)
		{
			_dataContext = dataContext;
			_mapper = mapper;
		}

        // Gets list of all vehicles and maps them out to the models.
        public async Task<List<VehicleModel>> GetAll()
        {
            var vehicles = await _dataContext.Vehicles.
                ProjectTo<VehicleModel>(_mapper.ConfigurationProvider).ToListAsync();

            return vehicles;
        }

        // Gets vehicle by an Id and returns a VehicleModel that is mapped to a Vehicle entity.
        public async Task<VehicleModel> Get(long id)
        {
            var vehicle = await _dataContext.Vehicles.FirstOrDefaultAsync(x => x.VehicleId == id);

            if (vehicle is null)
            {
                throw new IdNotFoundException(id);
            }

            return _mapper.Map<VehicleModel>(vehicle);
        }

        // Creates an VehicleModel and returns it.
        public async Task<VehicleModel> Add(VehicleModel vehicle)
        {
            var Vehicle = new Vehicle(vehicle.VehicleName, vehicle.StartupPrice, vehicle.IsRented, vehicle.Battery, vehicle.Lattitude,
                vehicle.Longtitude, vehicle.UnderMaintenance, vehicle.TypeId);

            await _dataContext.Vehicles.AddAsync(Vehicle);
            _dataContext.SaveChanges();

            return vehicle;
        }

        // Finds the first vehicle that has the same id as the argument it takes, if found it updates the VehicleModel with the same data as fed.
        // Otherwise throws and exception.
        // Returns an Entity that is mapped out to the model. reason for this is to return only the needed data and not all sensitive data.
        public async Task<VehicleModel> Update(long id, VehicleModel vehicle)
        {
            var Vehicle = await _dataContext.Vehicles.FirstOrDefaultAsync(x => x.VehicleId == id);

            if (Vehicle is null)
            {
                throw new IdNotFoundException(id);
            }
            else
            {
                Vehicle.VehicleName = vehicle.VehicleName;
                Vehicle.UnderMaintenance = vehicle.UnderMaintenance;
                Vehicle.TypeId = vehicle.TypeId;
                Vehicle.StartupPrice = vehicle.StartupPrice;
                Vehicle.Longtitude = vehicle.Longtitude;
                Vehicle.Lattitude = vehicle.Lattitude;
                Vehicle.IsRented = vehicle.IsRented;
                Vehicle.Battery = vehicle.Battery;
            }

            _dataContext.Vehicles.Update(Vehicle);
            _dataContext.SaveChanges();
            return _mapper.Map<VehicleModel>(Vehicle);
        }

        // Finds the first vehicle that has the same id as the argument it takes, if found removes the vehicle, if not throws exception.
        public async Task Delete(long id)
        {
            var vehicle = await _dataContext.Vehicles.FirstOrDefaultAsync(x => x.VehicleId == id);

            if (vehicle is null)
            {
                throw new IdNotFoundException(id);
            }
            _dataContext.Vehicles.Remove(vehicle);
            _dataContext.SaveChanges();
        }

    }
}

