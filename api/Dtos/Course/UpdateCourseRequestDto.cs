using System.ComponentModel.DataAnnotations;

namespace api.Dtos.Course
{
    /// <summary>
    /// DTO for updating an existing course
    /// </summary>
    public class UpdateCourseRequestDto
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(500)]
        public string Description { get; set; } = string.Empty;

        [Url]
        public string? ImageUrl { get; set; }

        [Required]
        [StringLength(100)]
        public string Schedule { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Professor { get; set; } = string.Empty;
    }
}