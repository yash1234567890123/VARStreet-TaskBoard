using Microsoft.EntityFrameworkCore;
using TaskBoard.Api.Data;
using TaskBoard.Api.Models;
using TaskBoard.Api.DTOs;

namespace TaskBoard.Api.Services
{
    public class ProjectService : IProjectService
    {
        private readonly AppDbContext _context;

        // This links this service to your database
        public ProjectService(AppDbContext context)
        {
            _context = context;
        }

        // This gets the list of projects and counts tasks for the UI cards
        public async Task<IEnumerable<ProjectDto>> GetAllProjectsAsync()
        {
            return await _context.Projects
                .Select(p => new ProjectDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    // Counting tasks for the small summary on each project card
                    TodoCount = _context.Tasks.Count(t => t.ProjectId == p.Id && t.Status == TaskStatus.Todo),
                    InProgressCount = _context.Tasks.Count(t => t.ProjectId == p.Id && t.Status == TaskStatus.InProgress),
                    DoneCount = _context.Tasks.Count(t => t.ProjectId == p.Id && t.Status == TaskStatus.Done)
                }).ToListAsync();
        }

        // This creates a new project in the database
        public async Task<ProjectDto> CreateProjectAsync(CreateProjectDto dto)
        {
            var project = new Project 
            { 
                Name = dto.Name, 
                Description = dto.Description 
            };

            _context.Projects.Add(project);
            await _context.SaveChangesAsync(); 

            return new ProjectDto 
            { 
                Id = project.Id, 
                Name = project.Name,
                Description = project.Description
            };
        }
    }
}
