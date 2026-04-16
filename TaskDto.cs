using TaskBoard.Api.Models;

namespace TaskBoard.Api.DTOs
{
    public class TaskDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public string Priority { get; set; } // We send these as strings to React
        public string Status { get; set; }
        public DateTime? DueDate { get; set; }
    }

    public class CreateTaskDto
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public TaskPriority Priority { get; set; }
        public DateTime? DueDate { get; set; }
    }
}
