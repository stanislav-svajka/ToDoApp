using ToDoAppBE.DTOs;
using ToDoAppBE.Entities;
using ToDoAppBE.Model;

namespace ToDoAppBE.Repository.IRepository;

public interface ITaskRepository
{
    Task<List<TaskEntity>> GetAllTasksEntities();

    Task<UserEntity> GetUserByName(string username);

    Task<List<TaskEntity>> GetTaskByGroup(string group);

    Task DeleteById(int id);

}