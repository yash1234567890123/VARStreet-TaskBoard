using TaskBoard.Api.DTOs;

namespace TaskBoard.Api.Services
{
    public interface IProjectService
    {
        Task<IEnumerable<ProjectDto>> GetAllProjectsAsync();
        Task<ProjectDto> CreateProjectAsync(CreateProjectDto dto);
    }
}
