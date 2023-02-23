using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDoAppBE.DTOs;
using ToDoAppBE.Entities;
using ToDoAppBE.Model;
using ToDoAppBE.Services.Interfaces;

namespace ToDoAppBE.Controllers;
    
[ApiController]
[Route("api/[controller]")]
public class TaskController : ControllerBase
{
    private readonly ITaskService _taskService;

    public TaskController(ITaskService taskService)
    {
        _taskService = taskService;
    }


    [Authorize]
    [HttpGet] //WORK ??
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAllAsync()
    {
        var tasks = await _taskService.GetAllAsync();
        return Ok(tasks);
    }
    
    
    [Authorize]
    [HttpGet("group/{group}")] //WORK
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetByGroupAsync(
        [Required, FromRoute(Name = "group")] string group
    )
    {
        var tasks = await _taskService.GetByGroupAsync(group);
        return Ok(tasks);
    }
    
    [Authorize]
    [HttpGet("user/{username}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetByUserIdAsync(
        [Required, FromRoute(Name = "username")] string username
    )
    {
        var tasks= await _taskService.GetTaskByUserIdAsync(username);
        return Ok(tasks);
    }

    [Authorize]
    [HttpDelete("{task_id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteAsync(
        [Required, FromRoute(Name = "task_id")] int taskId
    )
    { 
        await _taskService.DeleteByIdAsync(taskId);
        return Ok("delete successful");
    }

    [Authorize]
    [HttpPost] // WORK
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> CreateAsync(
        [Required, FromBody, Bind] TaskModel taskModel
    )
    {
        var task = await _taskService.CreateAsync(taskModel);
        return Ok(task);
    }

    [Authorize]
    [HttpPut("{task_id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateAsync(
        
        [Required,FromRoute(Name = "task_id")]int taskId,
        [Required, FromBody] TaskDto taskDto
    )
    {
        var task = await _taskService.UpdateAsync(taskId,taskDto);
        return Ok(task);
    }
    
}
