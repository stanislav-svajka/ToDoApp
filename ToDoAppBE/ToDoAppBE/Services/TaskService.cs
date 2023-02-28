using Microsoft.EntityFrameworkCore;
using ToDoAppBE.Database;
using ToDoAppBE.DTOs;
using ToDoAppBE.Entities;
using ToDoAppBE.Exceptions;
using ToDoAppBE.Model;
using ToDoAppBE.Repository;
using ToDoAppBE.Repository.IRepository;
using ToDoAppBE.Services.Interfaces;

namespace ToDoAppBE.Services;

public class TaskService : ITaskService
{
   
    private readonly ITaskRepository _taskRepository;

    public TaskService(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
       
    }
    
    public async Task<List<TaskDto>> GetAllAsync()
    {
        var entities = await _taskRepository.GetAllTasksEntities();
        
        if (entities == null)
        {
            throw new NotFoundException($"Tasks not found");
        }
        var result = entities.Select(x => x.ToDto()).ToList();
        
        return result;
    }

    public async Task<List<TaskEntity>> GetTaskByUserNameAsync(string username)
    {
        var user = await _taskRepository.GetTaskByUserName(username);
        
        if (user == null)
        {
            throw new NotFoundException($"Tasks not found");
        }
        
        var tasks = user.Tasks;
        return tasks;
    }

    public async Task<List<TaskDto>> GetByGroupAsync(string group)
    {
        var correctGroup = group.ToLower();

        var items = await _taskRepository.GetTaskByGroup(correctGroup);
        
        if (items == null)
        {
            throw new NotFoundException($"Tasks not found");
        }
        
        var dtos = items.Select(x => x.ToDto()).ToList();
        
        return dtos;
    }

    public async Task DeleteByIdAsync(int id)
    {
        var item = await _taskRepository.GetTaskById(id);
        
        if (item == null)
        {
            throw new NotFoundException($"Tasks not found");
        }

        await _taskRepository.RemoveTask(item);
        await _taskRepository.SaveChange();
    }

    public async Task<bool> CreateAsync(TaskModel taskModel)
    {
        var user = await _taskRepository.GetUserByTask(taskModel);
        
        
        var task = new TaskEntity
        {
            ExpirationTime = taskModel.Expirationtime,
            Description = taskModel.Description,
            Group = taskModel.Group,
            isCompleted = taskModel.isCompleted,
            Title = taskModel.Title,
            UserEntity = user,
        };

        await _taskRepository.AddTask(task);
        await _taskRepository.SaveChange();
        return true;
    }

    public async Task<bool> UpdateAsync( int taskId ,TaskDto taskDto)
    {
        var task = await _taskRepository.GetTaskById(taskId);

        if (task == null)
        {
            throw new NotFoundException($"Tasks not found");
        }
        
        task.Title = taskDto.Title;
        task.Description = taskDto.Description;
        task.Group = taskDto.Group;
        task.isCompleted = taskDto.isCompleted;
        task.ExpirationTime = taskDto.Expirationtime;

        await _taskRepository.UpdateTask(task);
        await _taskRepository.SaveChange();
        return true;
    }
}