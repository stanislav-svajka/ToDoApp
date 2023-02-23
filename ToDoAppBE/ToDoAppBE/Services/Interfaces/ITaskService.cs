using ToDoAppBE.DTOs;
using ToDoAppBE.Entities;
using ToDoAppBE.Model;

namespace ToDoAppBE.Services.Interfaces;

public interface ITaskService
{
    Task<List<TaskDto>> GetAllAsync();

    Task<List<TaskEntity>> GetTaskByUserIdAsync(string username);

    Task<List<TaskDto>> GetByGroupAsync(string group);

    Task DeleteByIdAsync(int id);

    Task<bool> CreateAsync(TaskModel taskModel);

    Task<bool> UpdateAsync(int taskId , TaskDto taskDto);
}