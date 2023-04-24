using System;
using LeMounAPI.Repositories.CustomExceptions;

namespace LeMounAPI.Repositories.UserRoleRepository
{
	public class UserRoleRepository : IModelRepository<UserRoleModel>
	{
        // Creating a reference to Data context and IMapper
        private readonly DataContext _dataContext;
		private readonly IMapper _mapper;

        // Creating a constructor, that initializez the context and mapper.
        public UserRoleRepository(DataContext dataContext, IMapper mapper)
		{
			_dataContext = dataContext;
			_mapper = mapper;
		}

        // Gets list of all userRoles and maps them out to the models.
        public async Task<List<UserRoleModel>> GetAll()
        {
            var userRoles = await _dataContext.Roles.
                ProjectTo<UserRoleModel>(_mapper.ConfigurationProvider).ToListAsync();

            return userRoles;
        }

        // Gets userRole by an Id and returns a UserRoleModel that is mapped to a User entity.
        public async Task<UserRoleModel> Get(long id)
        {
            var userRole = await _dataContext.Roles.FirstOrDefaultAsync(x => x.RoleId == id);

            if (userRole is null)
            {
                throw new IdNotFoundException(id);
            }

            return _mapper.Map<UserRoleModel>(userRole);
        }

        // Creates an UserRoleModel and returns it.
        public async Task<UserRoleModel> Add(UserRoleModel userRole)
        {
            var UserRole = new UserRole(userRole.Role);

            await _dataContext.Roles.AddAsync(UserRole);
            _dataContext.SaveChanges();

            return userRole;
        }

        // Finds the first role that has the same id as the argument it takes, if found it updates the UserRoleModel with the same data as fed.
        // Otherwise throws and exception.
        // Returns an Entity that is mapped out to the model. reason for this is to return only the needed data and not all sensitive data.
        public async Task<UserRoleModel> Update(long id, UserRoleModel userRole)
        {
            var UserRole = await _dataContext.Roles.FirstOrDefaultAsync(x => x.RoleId == id);

            if (UserRole is null)
            {
                throw new IdNotFoundException(id);
            }

            else
            {
                UserRole.Role = userRole.Role;
            }

            _dataContext.Roles.Update(UserRole);
            _dataContext.SaveChanges();

            return userRole;
        }

        // Finds the first role that has the same id as the argument it takes, if found removes the role, if not throws exception.
        public async Task Delete(long id)
        {
            var userRole = await _dataContext.Roles.FirstOrDefaultAsync(x => x.RoleId == id);

            if (userRole is null)
            {
                throw new IdNotFoundException(id);
            }
            _dataContext.Roles.Remove(userRole);
            _dataContext.SaveChanges();
        }
    }
}

