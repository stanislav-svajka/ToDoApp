using ToDoAppBE.Entities;

namespace ToDoAppBE.Repository.IRepository;

public interface IUserRepository
{
    Task<UserEntity> GetUserByName(string name);
    
    Task AddUser(UserEntity user);
    
    Task SaveChange();
}