using System.ComponentModel.DataAnnotations;

namespace TaskBoard.Api.Models
{
    public class Project
    {
        public int Id { get; set; } // The ID number (1, 2, 3...)

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } // The title of the project

        [MaxLength(300)]
        public string? Description { get; set; } // Extra details

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // The time it was made
    }
}
