using Microsoft.EntityFrameworkCore;
using ToDoAppBE.Entities;

namespace ToDoAppBE.Database;

public class ApplicationContext :DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
    { }

    public DbSet<UserEntity> Users { get; set; }
    
    public DbSet<TaskEntity> Tasks { get; set; }
}