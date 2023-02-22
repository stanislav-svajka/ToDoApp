using Microsoft.EntityFrameworkCore;
using ToDoAppBE.Database;
using ToDoAppBE.DTOs;
using ToDoAppBE.Entities;
using ToDoAppBE.Model;
using ToDoAppBE.Services.Interfaces;

namespace ToDoAppBE.Services;

public class TaskService : ITaskService
{
    private readonly ApplicationContext _context;

    public TaskService(ApplicationContext context)
    {
        _context = context;
    }
    
    public async Task<List<TaskDto>> GetAllAsync()
    {
        var items = await _context.Tasks.AsNoTracking().ToListAsync();
        
        if (items == null)
        {
            throw new Exception("Tasks not found");
        }

        var tasks = items.Select(x => x.ToDto()).ToList();

        return tasks;
    }

    public async Task<List<TaskEntity>> GetTaskByUserIdAsync(string username)
    {

        var user = await _context.Users
            .Include(x => x.Tasks)
            .SingleOrDefaultAsync(x => x.Username == username);
        
        if (user == null)
        {
            throw new Exception("Tasks not found");
        }

        var tasks = user.Tasks;
        
        return tasks;
    }

    public async Task<List<TaskDto>> GetByGroupAsync(string group)
    {
        var correctGroup = group.ToLower();
        
        var items = await _context.Tasks.AsNoTracking().Where(x=>x.Group == correctGroup).ToListAsync();
        
        if (items == null)
        {
            throw new Exception("Tasks not found");
        }
        
        var dtos = items.Select(x => x.ToDto()).ToList();

        return dtos;
    }

    public async Task DeleteByIdAsync(int id)
    {
        var item = await _context.Tasks.FirstOrDefaultAsync(x => x.Id == id);
        
        if (item == null)
        {
            throw new Exception("Task not found");
        }

        _context.Tasks.Remove(item);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> CreateAsync(TaskModel taskModel)
    {
        if (await _context.Tasks.AnyAsync(x => x.Title == taskModel.Title))
        {
            throw new Exception($"Product with name {taskModel.Title} already exists");
        }

        var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == taskModel.UserId);
        
        
        var task = new TaskEntity
        {
            //Id = taskModel.Id,
            //ExpirationTime = taskModel.Expirationtime,
            Description = taskModel.Description,
            Group = taskModel.Group,
            isCompleted = taskModel.isCompleted,
            Title = taskModel.Title,
            UserEntity = user,
        };

        await _context.Tasks.AddAsync(task);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> UpdateAsync(TaskDto taskDto)
    {
        var task = await _context.Tasks.FirstOrDefaultAsync(x => x.UserEntity.Id == taskDto.UserId);

        if (task == null)
        {
            throw new Exception("Empty");
        }

        if (await  _context.Tasks.AnyAsync(x=>x.Title == taskDto.Title && x.Id != taskDto.UserId))
        {
            throw new Exception("Already exist !");
        }

        task.Description = taskDto.Description;
        task.Group = taskDto.Group;
        task.isCompleted = taskDto.isCompleted;
        task.ExpirationTime = taskDto.Expirationtime;

        _context.Tasks.Update(task);
        await _context.SaveChangesAsync();
        return true;
    }
}