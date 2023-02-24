using NSubstitute;
using ToDoAppBE.Database;
using ToDoAppBE.DTOs;
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
    private TaskRepository _taskRepository;


    [SetUp]
    public void SetUp()
    {
        _userService = Substitute.For<IUserService>();
        _taskRepository = Substitute.For<TaskRepository>();
        
    }

    [Test]
    public async Task AddTaskAsync_ValidInput()
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

        await _taskRepository.GetTaskById(id);
        await _taskRepository.GetUserByTask(model);


        //Act
        var result = await _taskService.CreateAsync(model);

        //Asert
        Assert.True(result);
    }
}