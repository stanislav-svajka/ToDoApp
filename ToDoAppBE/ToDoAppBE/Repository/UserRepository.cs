using Microsoft.EntityFrameworkCore;
using ToDoAppBE.Database;
using ToDoAppBE.Entities;
using ToDoAppBE.Repository.IRepository;

namespace ToDoAppBE.Repository;

public class UserRepository : IUserRepository
{
    private readonly ApplicationContext _context;

    public UserRepository(ApplicationContext context)
    {
        _context = context;
    }
    
    public async Task<UserEntity> GetUserByName(string name)
    {
        var user = await _context.Users.SingleOrDefaultAsync(x => x.Username == name.ToLower());
        return user;
    }

    public async Task AddUser(UserEntity user)
    {
        await _context.Users.AddAsync(user);
    }

    public async Task SaveChange()
    {
        await _context.SaveChangesAsync();
    }
}