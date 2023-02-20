using Microsoft.EntityFrameworkCore;
using ToDoAppBE.Entities;

namespace ToDoAppBE.Database;

public class ApplicationContext :DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
    { }

    private DbSet<UserEntity> Users { get; set; }
    
    private DbSet<TaskEntity> Tasks { get; set; }
}