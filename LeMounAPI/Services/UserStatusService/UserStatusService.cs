using System;

namespace LeMounAPI.Services.StatusService
{
	public class UserStatusService : IModelService<UserStatusModel>
	{
        // Creating a reference to Data context and IMapper
        private readonly DataContext _context;
		private readonly IMapper _mapper;

        // Creating a constructor, that initializez the context and mapper.
        public UserStatusService(DataContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

        // Gets list of all statuses and maps them out to the models.
        public async Task<List<UserStatusModel>> GetAll()
        {
            var userStatuses = await _context.Statuses
                .ProjectTo<UserStatusModel>(_mapper.ConfigurationProvider).ToListAsync();

            return userStatuses;
        }

        // Gets user by an Id and returns a UserMoUserStatusModel that is mapped to a User entity.
        public async Task<UserStatusModel> Get(long id)
        {
            var userStatus = await _context.Statuses.FirstOrDefaultAsync(x => x.StatusId == id);

            if (userStatus is null)
            {
                throw new IdNotFoundException(id);
            }

            return _mapper.Map<UserStatusModel>(userStatus);
        }

        // Creates an UserStatusModel and returns it.
        public async Task<UserStatusModel> Add(UserStatusModel statusModel)
        {
            var userStatus = new UserStatus(statusModel.StatusName);

            await _context.Statuses.AddAsync(userStatus);
            _context.SaveChanges();
            return statusModel;
        }


        // Finds the first status that has the same id as the argument it takes, if found it updates the UserStatusModel with the same data as fed.
        // Otherwise throws and exception.
        // Returns an Entity that is mapped out to the model. reason for this is to return only the needed data and not all sensitive data.
        public async Task<UserStatusModel> Update(long id, UserStatusModel updatedStatus)
        {
            var userStatus = await _context.Statuses.FirstOrDefaultAsync(x => x.StatusId == id);

            if (userStatus is null)
            {
                throw new IdNotFoundException(id);
            }
            else
            {
                userStatus.StatusName = updatedStatus.StatusName;
            }

            _context.Statuses.Update(userStatus);
            _context.SaveChanges();

            return _mapper.Map<UserStatusModel>(userStatus);
        }

        public async Task Delete(long id)
        {
            var userStatus = await _context.Statuses.FirstOrDefaultAsync(x => x.StatusId == id);

            if (userStatus is null)
            {
                throw new IdNotFoundException(id);
            }

            _context.Statuses.Remove(userStatus);
            _context.SaveChanges();
        }


    }
}

