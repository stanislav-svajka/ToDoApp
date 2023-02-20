using System.ComponentModel.DataAnnotations;

namespace ToDoAppBE.DTOs;

public class UserDto
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    public Guid UserGuid { get; set; }
    
    [Required]
    public string FirstName { get; set; }
    
    [Required]
    public string LastName { get; set; }
    
    [Required]
    public string Email { get; set; }

    [Required] 
    public string Password { get; set; }

}