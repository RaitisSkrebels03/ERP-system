using Dollibar.Cllient.Dtos.TaskDto;
using Dollibar.Cllient.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Dollibar.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController
    {
        private readonly ITasksService _tasksService;

        public TasksController(ITasksService tasksService)
        {
            _tasksService = tasksService;
        }
        [HttpGet]
        public async Task<List<TaskDto>> GetTasks(string sortfield = "t.rowid", string sortorder = "ASC", long limit = 100,
                                                  long? page = null, string? sqlFilters = null)
        {
            return await _tasksService.GetTasks(sortfield, sortorder, limit, page, sqlFilters);
        }

        [HttpGet("{id:int}")]
        public async Task<TaskDto> GetTask(int id)
        {
            return await _tasksService.GetTask(id);
        }

        [HttpPost]
        public async Task<string> CreateTask(TaskDto task)
        {
            return await _tasksService.CreateTask(task);
        }

        [HttpPut("{id:int}")]
        public async Task<TaskDto> UpdateTask(int id, TaskDto task)
        {
            return await _tasksService.UpdateTask(id, task);
        }

        [HttpDelete("{id:int}")]
        public async Task<string> DeleteTask(int id)
        {
            return await _tasksService.DeleteTask(id);
        }
    }
}
