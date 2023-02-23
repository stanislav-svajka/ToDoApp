using Microsoft.AspNetCore.SignalR.Protocol;
using Microsoft.EntityFrameworkCore;
using ToDoAppBE.Database;
using ToDoAppBE.DTOs;
using ToDoAppBE.Entities;
using ToDoAppBE.Model;
using ToDoAppBE.Repository.IRepository;

namespace ToDoAppBE.Repository;

public class TaskRepository: ITaskRepository
{
    private readonly ApplicationContext _context;

    public TaskRepository(ApplicationContext context)
    {
        _context = context;
    }
    
   

    public async Task<List<TaskEntity>> GetAllTasksEntities()
    {
        var entities = await _context.Tasks.ToListAsync();
        
        return entities;
    }

    public async Task<UserEntity> GetUserByName(string username)
    {
        var user = await _context.Users
            .Include(x => x.Tasks)
            .SingleOrDefaultAsync(x => x.Username == username);
        return user;
    }

    public async Task<List<TaskEntity>> GetTaskByGroup(string group)
    {
        var items = await _context.Tasks.AsNoTracking().Where(x=>x.Group == group).ToListAsync();
        
        return items;
    }

    public async Task DeleteById(int id)
    {
        
    }
    
    
}