using Dollibar.Cllient.Dtos.ProjectDto;
using Dollibar.Cllient.Dtos.TaskDto;

namespace Dollibar.Cllient.Services.Interfaces
{
    public interface IProjectsService
    {
        Task<List<ProjectDto>> GetProjects(string sortfield = "t.rowid", string sortorder = "ASC", long limit = 100,
                                           long? page = null, string? thirdparty_ids = null, long? category = null, string? sqlFilters = null);
        Task<ProjectDto> GetProject(int id);
        Task<string> CreateProject(ProjectDto project);
        Task<ProjectDto> UpdateProject(int id, ProjectDto project);
        Task<string> DeleteProject(int id);
        Task<List<TaskDto>> GetProjectTasks(int id);
    }
}
