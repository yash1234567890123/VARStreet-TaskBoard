using TaskBoard.Api.DTOs;
using TaskBoard.Api.Models;

namespace TaskBoard.Api.Services
{
    public interface ITaskService
    {
        // This handles the pagination and filtering logic
        Task<PaginatedList<TaskDto>> GetTasksAsync(int projectId, string? status, string? sortBy, int page, int pageSize);
        Task<TaskDto> CreateTaskAsync(int projectId, CreateTaskDto dto);
    }

    // This is a special class to hold the "Metadata" (total pages, current page)
    public class PaginatedList<T>
    {
        public List<T> Data { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
    }
}
