using Microsoft.EntityFrameworkCore;
using TaskBoard.Api.Data;
using TaskBoard.Api.Models;
using TaskBoard.Api.DTOs;

namespace TaskBoard.Api.Services
{
    public class TaskService : ITaskService
    {
        private readonly AppDbContext _context;
        public TaskService(AppDbContext context) => _context = context;

        public async Task<PaginatedList<TaskDto>> GetTasksAsync(int projectId, string? status, string? sortBy, int page, int pageSize)
        {
            // 1. Start with all tasks for this project
            var query = _context.Tasks.Where(t => t.ProjectId == projectId).AsQueryable();

            // 2. FILTERING: If the user asked for a specific status
            if (!string.IsNullOrEmpty(status) && Enum.TryParse<TaskStatus>(status, out var statusEnum))
            {
                query = query.Where(t => t.Status == statusEnum);
            }

            // 3. SORTING: Arrange by DueDate or Title
            query = sortBy?.ToLower() == "date" 
                ? query.OrderBy(t => t.DueDate) 
                : query.OrderByDescending(t => t.CreatedAt);

            // 4. PAGINATION MATH: Figure out the pages
            var totalCount = await query.CountAsync();
            var totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

            // 5. SKIP AND TAKE: Only grab the 10 tasks for the current page
            var tasks = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(t => new TaskDto {
                    Id = t.Id,
                    Title = t.Title,
                    Description = t.Description,
                    Status = t.Status.ToString(),
                    Priority = t.Priority.ToString(),
                    DueDate = t.DueDate
                }).ToListAsync();

            return new PaginatedList<TaskDto> {
                Data = tasks,
                PageSize = pageSize,
                TotalCount = totalCount,
                TotalPages = totalPages
            };
        }

        public async Task<TaskDto> CreateTaskAsync(int projectId, CreateTaskDto dto)
        {
            var task = new TaskItem {
                ProjectId = projectId,
                Title = dto.Title,
                Description = dto.Description,
                Priority = dto.Priority,
                DueDate = dto.DueDate
            };

            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();

            return new TaskDto { Id = task.Id, Title = task.Title };
        }
    }
}
