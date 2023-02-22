using ToDoAppBE.DTOs;
using ToDoAppBE.Entities;

namespace ToDoAppBE.Services.Interfaces;

public interface ITaskService
{
    Task<List<TaskDto>> GetAllAsync();

    Task<List<TaskEntity>> GetTaskByUserIdAsync(string username);

    Task<List<TaskDto>> GetByGroupAsync(string group);

    Task DeleteByIdAsync(int id);

    Task<bool> CreateAsync(TaskDto taskDto);

    Task<bool> UpdateAsync(TaskDto taskDto);
}