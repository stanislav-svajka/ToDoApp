using System.ComponentModel.DataAnnotations;

namespace ToDoAppBE.DTOs;

public class UserDto
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Username { get; set; }
    
    [Required] 
    public string Password { get; set; }

}