using Dollibar.Cllient.Dtos.TaskDto;
using Dollibar.Cllient.Services.Interfaces;
using Xunit.Extensions.Ordering;

namespace Dollibar.Test
{
    [Order(13)]
    public class TasksServiceTest
    {
        private readonly ITasksService _tasksService;
        private static int taskId;
        public TasksServiceTest(ITasksService tasksService) => _tasksService = tasksService;

        [Fact, Order(1)]
        public async Task CreateTask()
        {
            TaskDto task = new TaskDto()
            {
                Ref = "RF004",
                Label = "Our label",
                Description = "This is description",
                Budget_amount = "200",
                Fk_project = "2",
                Fk_task_parent = "0"
            };
            var result = await _tasksService.CreateTask(task);

            Assert.NotNull(result);
            Assert.IsType<string>(result);
        }

        [Fact, Order(2)]
        public async Task GetTasks()
        {
            var result = await _tasksService.GetTasks();
            Assert.NotNull(result);
            Assert.IsType<List<TaskDto>>(result);
            taskId = result.Last().Id;
        }

        [Fact, Order(3)]
        public async Task GetTask()
        {
            var result = await _tasksService.GetTask(taskId);
            Assert.NotNull(result);
            Assert.IsType<TaskDto>(result);
            Assert.Equal("RF004", result.Ref);
            Assert.Equal("Our label", result.Label);
            Assert.Equal("2", result.Fk_project);
            Assert.Equal("This is description", result.Description);
        }

        [Fact, Order(4)]
        public async Task UpdateTask()
        {
            TaskDto task = new TaskDto()
            {
                Ref = "RF004",
                Label = "Updated label",
                Description = "This is description",
                Budget_amount = "300",
                Fk_project = "2",
                Fk_task_parent = "0"

            };
            var result = await _tasksService.UpdateTask(taskId, task);
            Assert.NotNull(result);
            Assert.IsType<TaskDto>(result);
            Assert.Equal("RF004", result.Ref);
            Assert.Equal("Updated label", result.Label);
        }

        [Fact, Order(5)]
        public async Task DeleteTask()
        {
            var result = await _tasksService.DeleteTask(taskId);
            Assert.NotNull(result);
            Assert.IsType<string>(result);
        }

    }
}
