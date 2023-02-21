using ToDoAppBE.Entities;

namespace ToDoAppBE.Services.Interfaces;

public interface IUserService
{
    Task<int> Register(UserEntity user, string password);

    Task<string> Login(string username, string password);

    Task<bool> UserExist(string username);
}