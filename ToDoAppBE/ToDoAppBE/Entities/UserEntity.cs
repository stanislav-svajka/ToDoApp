using System.ComponentModel.DataAnnotations;

namespace ToDoAppBE.Entities;

public class UserEntity
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    public Guid UserGuid { get; set; }
    
    [Required]
    public string FirstName { get; set; } = string.Empty;
    
    [Required]
    public string LastName { get; set; } = string.Empty;
    
    [Required]
    public string Email { get; set; } = string.Empty;
    
    [Required]
    public byte[] PasswordHash { get; set; } = new byte[0];
    
    [Required]
    public byte[] PasswordSalt { get; set; } = new byte[0];
    
    public List<TaskEntity> Tasks { get; set; }
}