using System;

namespace LeMounAPI.Repositories.VehicleRepository
{
	public class VehicleRepository : IModelRepository<VehicleModel>
	{
		private readonly DataContext _dataContext;
		private readonly IMapper _mapper;

		public VehicleRepository(DataContext dataContext, IMapper mapper)
		{
			_dataContext = dataContext;
			_mapper = mapper;
		}

        public async Task<List<VehicleModel>> GetAll()
        {
            var vehicles = await _dataContext.Vehicles.
                ProjectTo<VehicleModel>(_mapper.ConfigurationProvider).ToListAsync();

            return vehicles;
        }

        public async Task<VehicleModel> Get(long id)
        {
            var vehicle = await _dataContext.Vehicles.FirstOrDefaultAsync(x => x.VehicleId == id);

            if (vehicle is null)
            {
                throw new IdNotFoundException(id);
            }

            return _mapper.Map<VehicleModel>(vehicle);
        }

        public async Task<VehicleModel> Add(VehicleModel vehicle)
        {
            var Vehicle = new Vehicle(vehicle.VehicleName, vehicle.StartupPrice, vehicle.IsRented, vehicle.Battery, vehicle.Lattitude,
                vehicle.Longtitude, vehicle.UnderMaintenance, vehicle.TypeId);

            await _dataContext.Vehicles.AddAsync(Vehicle);
            _dataContext.SaveChanges();

            return vehicle;
        }

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

