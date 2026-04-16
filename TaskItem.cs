using System.ComponentModel.DataAnnotations;

namespace TaskBoard.Api.Models
{
    public class TaskItem
    {
        public int Id { get; set; }

        [Required]
        public int ProjectId { get; set; } // Links this task to a Project

        [Required]
        [MaxLength(150)]
        public string Title { get; set; }

        public string? Description { get; set; }

        public TaskPriority Priority { get; set; } = TaskPriority.Medium;
        public TaskStatus Status { get; set; } = TaskStatus.Todo;

        public DateTime? DueDate { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }

    // These are "Enums" - they act like a fixed dropdown list
    public enum TaskPriority { Low, Medium, High, Critical }
    public enum TaskStatus { Todo, InProgress, Review, Done }
}
