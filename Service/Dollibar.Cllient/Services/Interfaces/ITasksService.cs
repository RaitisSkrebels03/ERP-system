using Dollibar.Cllient.Dtos.TaskDto;

namespace Dollibar.Cllient.Services.Interfaces
{
    public interface ITasksService
    {
        Task<List<TaskDto>> GetTasks(string sortfield = "t.rowid", string sortorder = "ASC", long limit = 100,
                                     long? page = null, string? sqlFilters = null);
        Task<TaskDto> GetTask(int id);
        Task<string> CreateTask(TaskDto task);
        Task<TaskDto> UpdateTask(int id, TaskDto task);
        Task<string> DeleteTask(int id);
    }
}
