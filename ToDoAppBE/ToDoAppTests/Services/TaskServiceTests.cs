using NSubstitute;
using ToDoAppBE.Database;
using ToDoAppBE.DTOs;
using ToDoAppBE.Entities;
using ToDoAppBE.Exceptions;
using ToDoAppBE.Model;
using ToDoAppBE.Repository;
using ToDoAppBE.Repository.IRepository;
using ToDoAppBE.Services;
using ToDoAppBE.Services.Interfaces;

namespace ToDoAppTests.Services;

[TestFixture]
public class TaskServiceTests
{
    private ITaskService _taskService;
    private IUserService _userService;
    private ApplicationContext _applicationContext;
    private ITaskRepository _taskRepository;


    [SetUp]
    public void SetUp()
    {
        
        _userService = Substitute.For<IUserService>();
        _taskRepository = Substitute.For<ITaskRepository>();
        _taskService = new TaskService(_taskRepository);
    }

    [Test]
    public async Task AddTaskAsync_ValidInput_AddItemToTasks()
    {
        //Arrange
        var id = 1;
        var userId = 1;
        var descrtitpon = "aaa";
        var group = "bbb";
        var title = "ccc";
        var isComplete = false;
        
        TaskModel model = new TaskModel
        {
            UserId = userId,
            Description = descrtitpon,
            Group = group,
            isCompleted = isComplete,
            Title = title,
        };

        _taskRepository.GetTaskById(id).Returns(Task.FromResult(new TaskEntity()));

        //Act
        var result = await _taskService.CreateAsync(model);

        //Assert
        Assert.True(result);
    }


    [Test]
    public async Task getItemAsync_validoutput_getItemBygroup()
    {
        //Arrange
        var group = "string";
        var task = new TaskEntity
        {
            Id = 1,
            CreatedTime = DateTime.UtcNow,
            Description = "string",
            ExpirationTime = DateTime.UtcNow.AddDays(2),
            Group = "string",
            isCompleted = false,
            Title = "title",
            UserEntity = new UserEntity(),
            UserEntityId = 1
        };
        List<TaskEntity> taskList = new List<TaskEntity>();
        
        taskList.Add(task);
        //Act
         _taskRepository.GetTaskByGroup(group).Returns(Task.FromResult(taskList));
         
        var items = await _taskRepository.GetTaskByGroup(group);

        //Assert
        Assert.IsNotEmpty(items);

    }

    [Test]
    public async Task AddAyinc_TaskNotExist_Badrequest()
    {
        //Arrange

        var group = "dusan";
        var listTaskEntity = new List<TaskEntity>();
        
        
        var task = await _taskRepository.GetTaskByGroup(group);

        Assert.ThrowsAsync<NotFoundException>((() => _taskRepository.GetTaskByGroup(group)));
    }

    [Test]
    public async Task DeleteFromList()
    {
        //Arrange
        var group = "string";
        var task0 = new TaskEntity
        {
            Id = 1,
            CreatedTime = DateTime.UtcNow,
            Description = "string",
            ExpirationTime = DateTime.UtcNow.AddDays(2),
            Group = "string",
            isCompleted = false,
            Title = "title",
            UserEntity = new UserEntity(),
            UserEntityId = 1
        };
        List<TaskEntity> taskList = new List<TaskEntity>();
        
        taskList.Add(task0);
        
        //Act
        _taskRepository.GetTaskByGroup(group).Returns(Task.FromResult(taskList));
         
        var items = await _taskRepository.GetTaskByGroup(group);
        
        //Arrange
        var task = new TaskEntity
        {
            Id = 1,
            CreatedTime = DateTime.UtcNow,
            Description = "string",
            ExpirationTime = DateTime.UtcNow.AddDays(2),
            Group = "string",
            isCompleted = false,
            Title = "title",
            UserEntity = new UserEntity(),
            UserEntityId = 1
        };

        //Act
        var result = _taskRepository.RemoveTask(task).Returns(Task.FromResult(items));
        
        //Assert
        
        //Assert.IsEmpty(result);
        
    }
    
    
    
}