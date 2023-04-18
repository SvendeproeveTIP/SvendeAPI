using System;
using LeMounAPI.Models;

namespace LeMounAPI.Services.UserService
{
    public class UserService : IModelService<User>
    {
        //Meanwhile a List of all users here 

        private static List<User> Users = new List<User>
            {
                new User
                {   UserId = 1,
                    Email = "AnnMia@gmail.com",
                    Password = "1234",
                    StatusId = 1,
                    RoleId = 1
                },
                 new User
                {   UserId = 2,
                    Email = "Iasemin-Florin@gmail.com",
                    Password = "1234",
                    StatusId = 1,
                    RoleId = 1
                }
            };
        public void Add(User user)
        {
            Users.Add(user);
        }

        public void Delete(long id)
        {
            var user = Users.FirstOrDefault(x => x.UserId == id);

            if (user is null)
            {
                throw new IdNotFoundException(id);
            }

            Users.Remove(user);
        }

        public User Get(long id)
        {
            User user = Users.FirstOrDefault(x => x.UserId == id);

            if (user == null)
            {
                throw new IdNotFoundException(id);
            }
            return user;
        }

        public List<User> GetAll()
        {
            if (Users == null)
            {
                Console.WriteLine("No users exist");
            }
            return Users;
        }

        public User Update(long id, User updatedUser)
        {
            var user = Users.FirstOrDefault(x => x.UserId == id);

            if (user == null)
            {
                throw new IdNotFoundException(user.UserId);
            }

            user = updatedUser;

            return user;
        }
    }
}

