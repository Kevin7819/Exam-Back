using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace api.Dtos.Course
{
    /// <summary>
    /// DTO for creating a new course
    /// </summary>
    public class CreateCourseRequestDto
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(500)]
        public string Description { get; set; } = string.Empty;

        [Required]
        public IFormFile? ImageFile { get; set; }

        [Required]
        [StringLength(100)]
        public string Schedule { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Professor { get; set; } = string.Empty;
    }
}
