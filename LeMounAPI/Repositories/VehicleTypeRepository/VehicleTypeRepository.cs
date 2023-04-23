using System;
using LeMounAPI.Models;

namespace LeMounAPI.Repositories.VehicleTypeRepository
{
	public class VehicleTypeRepository : IModelRepository<VehicleTypeModel>
	{
        // Creating a reference to Data context and IMapper
        private readonly DataContext _dataContext;
		private readonly IMapper _mapper;

        // Creating a constructor, that initializez the context and mapper.
        public VehicleTypeRepository(DataContext dataContext, IMapper mapper)
		{
			_dataContext = dataContext;
			_mapper = mapper;
		}

        // Gets list of all vehicleTypes and maps them out to the models.
        public async Task<List<VehicleTypeModel>> GetAll()
        {
            var vehicleTypes = await _dataContext.VehicleTypes.
                ProjectTo<VehicleTypeModel>(_mapper.ConfigurationProvider).ToListAsync();
            return vehicleTypes;
        }

        public async Task<VehicleTypeModel> Get(long id)
        {
            var vehicleType = await _dataContext.VehicleTypes.FirstOrDefaultAsync(x => x.TypeId == id);

            if (vehicleType is null)
            {
                throw new IdNotFoundException(id);
            }

            return _mapper.Map<VehicleTypeModel>(vehicleType);
        }

        public async Task<VehicleTypeModel> Add(VehicleTypeModel vehicleType)
        {
            var type = new VehicleType(vehicleType.Type);

            await _dataContext.VehicleTypes.AddAsync(type);
            _dataContext.SaveChanges();

            return vehicleType;
        }


        public async Task<VehicleTypeModel> Update(long id, VehicleTypeModel vehicleType)
        {
            var type = await _dataContext.VehicleTypes.FirstOrDefaultAsync(x => x.TypeId == id);

            if (type is null)
            {
                throw new IdNotFoundException(id);
            }
            else
            {
                type.Type = vehicleType.Type;
            }
            _dataContext.VehicleTypes.Update(type);
            _dataContext.SaveChanges();
            return vehicleType;
        }

        public async Task Delete(long id)
        {
            var vehicleType = await _dataContext.VehicleTypes.FirstOrDefaultAsync(x => x.TypeId == id);

            if (vehicleType is null)
            {
                throw new IdNotFoundException(id);
            }

            _dataContext.VehicleTypes.Remove(vehicleType);
            _dataContext.SaveChanges();
        }
    }
}

