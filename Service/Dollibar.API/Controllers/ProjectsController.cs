using Dollibar.Cllient.Dtos.ProjectDto;
using Dollibar.Cllient.Dtos.TaskDto;
using Dollibar.Cllient.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Dollibar.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectsController
    {
        private readonly IProjectsService _projectsService;

        public ProjectsController(IProjectsService projectsService)
        {
            _projectsService = projectsService;
        }

        [HttpGet]
        public async Task<List<ProjectDto>> GetProjects(string sortfield = "t.rowid", string sortorder = "ASC", long limit = 100, 
                                                        long? page = null, string? thirdparty_ids = null, long? category = null, string? sqlFilters = null)
        {
            return await _projectsService.GetProjects(sortfield, sortorder, limit, page, thirdparty_ids, category, sqlFilters);
        }

        [HttpGet("{id:int}")]
        public async Task<ProjectDto> GetProject(int id)
        {
            return await _projectsService.GetProject(id);
        }

        [HttpGet("{id:int}/tasks")]
        public async Task<List<TaskDto>> GetProjectTasks(int id)
        {
            return await _projectsService.GetProjectTasks(id);
        }

        [HttpPost]
        public async Task<string> CreateProject(ProjectDto project)
        {
            return await _projectsService.CreateProject(project);
        }

        [HttpPut("{id:int}")]
        public async Task<ProjectDto> UpdateProject(int id, ProjectDto project)
        {
            return await _projectsService.UpdateProject(id, project);
        }

        [HttpDelete("{id:int}")]
        public async Task<string> DeleteProject(int id)
        {
            return await _projectsService.DeleteProject(id);
        }
    }
}
