using System;
namespace LeMounAPI.Services
{
	public interface IModelService<TEntity>
	{
        //List<User> GetUsers();    ---> All of this is is just incase want to make a IService interface for all models.

        //User GetUser(long id);

        //User AddUser(User user);

        //User UpdateUser(User dbUser, User user);

        //User DeleteUser(long id);

        // Chose to use TEntity because this can actually be used as a basic Crud Service.
        // Because it can works for all if not almost all of our models.

        // return type is void for Add, Update and Delete, but we can change it eventually to and TEntity.
        // So that when we call it we choose which return type to give it, if we wanna return the deleted user for example.

        Task<List<TEntity>> GetAll();

		Task<TEntity> Get(long id);

		Task<TEntity> Add(TEntity entity);

		Task<TEntity> Update(long id, TEntity entity);

		Task Delete(long id);
	}
}

