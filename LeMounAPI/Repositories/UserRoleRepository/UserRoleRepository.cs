using System;

namespace LeMounAPI.Repositories.UserRoleRepository
{
	public class UserRoleRepository : IModelRepository<UserRoleModel>
	{
		private readonly DataContext _dataContext;
		private readonly IMapper _mapper;

		public UserRoleRepository(DataContext dataContext, IMapper mapper)
		{
			_dataContext = dataContext;
			_mapper = mapper;
		}

        public async Task<List<UserRoleModel>> GetAll()
        {
            var userRoles = await _dataContext.Roles.
                ProjectTo<UserRoleModel>(_mapper.ConfigurationProvider).ToListAsync();

            return userRoles;
        }

        public async Task<UserRoleModel> Get(long id)
        {
            var userRole = await _dataContext.Roles.FirstOrDefaultAsync(x => x.RoleId == id);

            if (userRole is null)
            {
                throw new IdNotFoundException(id);
            }

            return _mapper.Map<UserRoleModel>(userRole);
        }

        public async Task<UserRoleModel> Add(UserRoleModel userRole)
        {
            var UserRole = new UserRole(userRole.Role);

            await _dataContext.Roles.AddAsync(UserRole);
            _dataContext.SaveChanges();

            return userRole;
        }

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

