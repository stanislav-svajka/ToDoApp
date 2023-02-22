using System.ComponentModel.DataAnnotations;
using ToDoAppBE.DTOs;

namespace ToDoAppBE.Entities;

public class UserEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Username { get; set; } = string.Empty;

    [Required]
    public byte[] PasswordHash { get; set; } = new byte[0];
    
    [Required]
    public byte[] PasswordSalt { get; set; } = new byte[0];
    
    public List<TaskEntity> Tasks { get; set; }

}