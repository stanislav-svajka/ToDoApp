using ToDoAppBE.DTOs;
using ToDoAppBE.Entities;
using ToDoAppBE.Model;

namespace ToDoAppBE.Repository.IRepository;

public interface ITaskRepository
{
    Task<List<TaskEntity>> GetAllTasksEntities();

    Task<UserEntity> GetTaskByUserName(string username);

    Task<List<TaskEntity>> GetTaskByGroup(string group);

    Task<TaskEntity> GetTaskById(int id);

    Task<UserEntity> GetUserByTask(TaskModel taskModel);

    Task AddTask(TaskEntity task);

    Task RemoveTask(TaskEntity taskEntity);

    Task SaveChange();

    Task UpdateTask(TaskEntity taskEntity);

}