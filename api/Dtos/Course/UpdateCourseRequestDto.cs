using System.ComponentModel.DataAnnotations;

namespace api.Dtos.Course
{
    /// <summary>
    /// Data Transfer Object for updating an existing course
    /// </summary>
    public class UpdateCourseRequestDto
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty; // Updated course name

        [Required]
        [StringLength(500)]
        public string Description { get; set; } = string.Empty; // Updated description

        [Url]
        public string? ImageUrl { get; set; } // New or existing image URL (optional)

        [Required]
        [StringLength(100)]
        public string Schedule { get; set; } = string.Empty; // Updated schedule

        [Required]
        [StringLength(100)]
        public string Professor { get; set; } = string.Empty; // Updated professor name
    }
}
