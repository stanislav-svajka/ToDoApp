using Microsoft.EntityFrameworkCore;
using ToDoAppBE.Database;
using ToDoAppBE.DTOs;
using ToDoAppBE.Entities;
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

    public async Task<bool> CreateAsync(TaskDto taskDto)
    {
        if (await _context.Tasks.AnyAsync(x => x.Title == taskDto.Title))
        {
            throw new Exception($"Product with name {taskDto.Title} already exists");
        }

        var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == taskDto.UserId);
        
        
        var task = new TaskEntity
        {
            Id = taskDto.Id,
            ExpirationTime = taskDto.Expirationtime,
            Description = taskDto.Description,
            Group = taskDto.Group,
            //UserEntiy
            isCompleted = taskDto.isCompleted,
            Title = taskDto.Title,
            UserEntity = user,
        };

        await _context.Tasks.AddAsync(task);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> UpdateAsync(TaskDto taskDto)
    {
        var task = await _context.Tasks.FirstOrDefaultAsync(x => x.Id == taskDto.Id);

        if (task == null)
        {
            throw new Exception("Empty");
        }

        if (await  _context.Tasks.AnyAsync(x=>x.Title == taskDto.Title && x.Id != taskDto.Id))
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