using NSubstitute;
using ToDoAppBE.Database;
using ToDoAppBE.DTOs;
using ToDoAppBE.Model;
using ToDoAppBE.Services;
using ToDoAppBE.Services.Interfaces;

namespace ToDoAppTests.Services;


[TestFixture]
public class TaskServiceTests
{
    // private ITaskService _taskService;
    // private IUserService _userService;
    // private ApplicationContext _applicationContext;
    //
    //
    // [SetUp]
    // public void SetUp()
    // {
    //     _userService = Substitute.For<IUserService>();
    //    // _taskService = new TaskService(_applicationContext);
    // }
    //
    // [Test]
    // public async Task AddTaskAsync_ValidInput()
    // {
    //     //Arrange
    //     var id = 1;
    //     var userId = 1;
    //     var createdTime = DateTime.UtcNow;
    //     var expirationTime = DateTime.UtcNow.AddDays(2);
    //     var descrtitpon = "aaa";
    //     var group = "bbb";
    //     var title = "ccc";
    //     var isComplete = false;
    //     
    //     TaskModel model = new TaskModel
    //     {
    //         UserId = userId,
    //         Description = descrtitpon,
    //         Group = group,
    //         isCompleted = isComplete,
    //         Title = title,
    //     };
    //
    //     var expected = new TaskDto
    //     {
    //         Id = id,
    //         UserId = userId,
    //         CreatedTime = createdTime,
    //         Expirationtime = expirationTime,
    //         Description = descrtitpon,
    //         Group = group,
    //         isCompleted = isComplete,
    //         Title = title
    //     };
    //     
    //     //Act
    //     var result = await _taskService.CreateAsync(model);
    //
    //     //Asert
    //     Assert.True(true);
    // }

    
}