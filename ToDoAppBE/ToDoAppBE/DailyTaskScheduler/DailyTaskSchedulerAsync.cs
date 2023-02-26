using System;
using System.Threading;
using System.Threading.Tasks;
using ToDoAppBE.Repository.IRepository;

public class DailyTaskSchedulerAsync
{
    private Timer _timer;
    private readonly ITaskRepository _taskRepository;

    public DailyTaskSchedulerAsync(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public async Task StartAsync()
    {
       
        var now = DateTime.Now;
        var nextMidnight = now.AddDays(1).Date;
        var timeUntilMidnight = nextMidnight - now;
        
        _timer = new Timer(async _ =>
        {
            var dodo = await _taskRepository.GetAllTasksEntities();

            foreach (var task in dodo)
            {
                if (task.isCompleted == true)
                {
                    await _taskRepository.RemoveTask(task);
                    await _taskRepository.SaveChange();
                }
            }

        }, null, timeUntilMidnight, TimeSpan.FromHours(24));
    }

    public void Stop()
    {
        _timer?.Dispose();
        _timer = null;
    }
}