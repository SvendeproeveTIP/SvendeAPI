using System;
using AutoMapper.QueryableExtensions;
using LeMounAPI.Models;

namespace LeMounAPI.Repositories.UserRepository
{
    public class UserRepository : IModelRepository<UserModel>
    {

        // Creating a reference to Data context and IMapper
        private readonly DataContext _context;
        private readonly IMapper  _mapper;


        // Creating a constructor, that initializez the context and mapper.
        public UserRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
    
        // Gets list of all users and maps them out to the models.
        public async Task<List<UserModel>> GetAll()
        {
            var users = await _context.Users
                .ProjectTo<UserModel>(_mapper.ConfigurationProvider).ToListAsync();

            return users;
        }

        // Gets user by an Id and returns a UserModel that is mapped to a User entity.
        public async Task<UserModel> Get(long id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.UserId == id);

            return _mapper.Map<UserModel>(user);
        }

        // Creates an UserModel and returns it.
        public async Task<UserModel> Add(UserModel user)
        {
            var User = new User(user.Email, user.Password, user.StatusId, user.RoleId);

            await _context.Users.AddAsync(User);
            _context.SaveChanges();
            return user;
        }


        // Finds the first user that has the same id as the argument it takes, if found it updates the UserModel with the same data as fed.
        // Otherwise throws and exception.
        // Returns an Entity that is mapped out to the model. reason for this is to return only the needed data and not all sensitive data.
        public async Task<UserModel> Update(long id, UserModel updatedUser)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.UserId == id);

            if (user is null)
            {
                throw new IdNotFoundException(id);
            }
            else
            {
                user.Email = updatedUser.Email;
                user.Password = updatedUser.Password;
                user.StatusId = updatedUser.StatusId;
                user.RoleId = updatedUser.RoleId;
            }

            _context.Users.Update(user);
            _context.SaveChanges();

            return _mapper.Map<UserModel>(user);
        }

        // Finds the first user that has the same id as the argument it takes, if found removes the user, if not throws exception.
        public async Task Delete(long id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.UserId == id);

            if (user is null)
            {
                throw new IdNotFoundException(id);
            }

            _context.Users.Remove(user);
            _context.SaveChanges();
        }
    }
}

