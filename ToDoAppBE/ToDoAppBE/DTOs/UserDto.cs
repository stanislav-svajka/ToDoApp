using System.ComponentModel.DataAnnotations;

namespace ToDoAppBE.DTOs;

public class UserDto
{
    [Required]
    public string Username { get; set; }
    
    [Required] 
    public string Password { get; set; }

}