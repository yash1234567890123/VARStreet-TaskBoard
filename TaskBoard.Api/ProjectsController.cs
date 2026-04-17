using Microsoft.AspNetCore.Mvc;
using TaskBoard.Api.DTOs;
using TaskBoard.Api.Services;

namespace TaskBoard.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // This makes the URL: /api/projects
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService _projectService;

        // "Dependency Injection": We ask the app to give us the service we made earlier
        public ProjectsController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        // GET: /api/projects
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectDto>>> GetProjects()
        {
            var projects = await _projectService.GetAllProjectsAsync();
            return Ok(projects); // Returns status code 200
        }

        // POST: /api/projects
        [HttpPost]
        public async Task<ActionResult<ProjectDto>> CreateProject(CreateProjectDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var createdProject = await _projectService.CreateProjectAsync(dto);
            
            // Returns status code 201 (Created)
            return CreatedAtAction(nameof(GetProjects), new { id = createdProject.Id }, createdProject);
        }
    }
}
