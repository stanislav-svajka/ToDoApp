using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using ToDoAppBE.DTOs;

namespace ToDoAppBE.Entities;

public class TaskEntity
{
    [Key] 
    public int Id { get; set; }
    
    //[ForeignKey("UserEntity")]
    public int UserEntityId { get; set; }

    public UserEntity? UserEntity { get; set; }

    public DateTime CreatedTime { get; set; } = DateTime.UtcNow;

    public DateTime? ExpirationTime { get; set; }
    
    public string Description { get; set; }
    
    public string Title { get; set; }
    
    public bool isCompleted { get; set; }
    
    public string Group { get; set; }

    public TaskDto ToDto()
    {
        return new TaskDto
        {
            Id = this.Id,
            UserId = UserEntityId,
            CreatedTime = this.CreatedTime,
            Expirationtime = this.ExpirationTime,
            Description = this.Description,
            Title = this.Title,
            isCompleted = this.isCompleted,
            Group = this.Group
        };
    }
    
    
}