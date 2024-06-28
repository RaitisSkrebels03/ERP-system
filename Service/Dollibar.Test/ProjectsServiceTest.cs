using Dollibar.Cllient.Dtos.ProjectDto;
using Dollibar.Cllient.Services.Interfaces;
using Xunit.Extensions.Ordering;

namespace Dollibar.Test
{
    [Order(9)]
    public class ProjectsServiceTest
    {
        private readonly IProjectsService _projectsService;
        private static int projectId;

        public ProjectsServiceTest(IProjectsService projectsService) => _projectsService = projectsService;


        [Fact, Order(1)]
        public async Task CreateProject()
        {
            ProjectDto project = new ProjectDto()
            {
                Ref = "0028",
                Title = "Our title",
                Description = "This is description",
                Fk_project = "2",
                Public = "0",
                Budget_amount = "3000"
            };
            var result = await _projectsService.CreateProject(project);

            Assert.NotNull(result);
            Assert.IsType<string>(result);
        }

        [Fact, Order(2)]
        public async Task GetProjects()
        {
            var result = await _projectsService.GetProjects();
            Assert.NotNull(result);
            Assert.IsType<List<ProjectDto>>(result);
            projectId = result.Last().Id;
        }

        [Fact, Order(3)]
        public async Task GetProject()
        {
            var result = await _projectsService.GetProject(projectId);
            Assert.NotNull(result);
            Assert.IsType<ProjectDto>(result);
            Assert.Equal("0028", result.Ref);
            Assert.Equal("Our title", result.Title);
            Assert.Equal("0", result.Public);
        }

        [Fact, Order(4)]
        public async Task UpdateProject()
        {
            ProjectDto project = new ProjectDto()
            {
                Ref = "0028",
                Title = "Updated title"
            };
            var result = await _projectsService.UpdateProject(projectId, project);
            Assert.NotNull(result);
            Assert.IsType<ProjectDto>(result);
            Assert.Equal("0028", result.Ref);
            Assert.Equal("Updated title", result.Title);
        }

        [Fact, Order(5)]
        public async Task DeleteProject()
        {
            var result = await _projectsService.DeleteProject(projectId);
            Assert.NotNull(result);
            Assert.IsType<string>(result);
        }

    }
}