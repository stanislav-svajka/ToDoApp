namespace ToDoAppBE.Model;

public class TaskModel
{
    //public int Id { get; set; }
    
    public int UserId { get; set; }
    
    // public DateTime CreatedTime { get; set; } = DateTime.UtcNow;
    
    public DateTime? Expirationtime { get; set; }

    public string Description { get; set; }
    
    public string Title { get; set; }

    public bool isCompleted { get; set; } 

    public string Group { get; set; } = "undefined";
}