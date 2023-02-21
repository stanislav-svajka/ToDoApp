using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace ToDoAppBE.Entities;

public class TaskEntity
{
    [Key] 
    public int Id { get; set; }

    public DateTime CreatedTime { get; set; } = DateTime.UtcNow;

    public DateTime? ExpirationTime { get; set; }
    
    public string Description { get; set; }
    
    public string Title { get; set; }
    
    public bool isCompleted { get; set; }
    
    public string Group { get; set; }
}