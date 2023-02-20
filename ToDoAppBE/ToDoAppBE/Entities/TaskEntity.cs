using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace ToDoAppBE.Entities;

public class TaskEntity
{
    [Key] public int TaskId { get; set; }

    [Required]
    public Guid TaskGuid { get; set; }

    public DateTime CreatedTime { get; set; } = DateTime.UtcNow;

    public DateTime? ExpirationTime { get; set; }
    
    [Required]
    public string Description { get; set; }
    
    [Required]
    public string Title { get; set; }
    
    public bool isCompleted { get; set; }
    
    [Required]
    public string Group { get; set; }
}