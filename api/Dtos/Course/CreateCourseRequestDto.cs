using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace api.Dtos.Course
{
    /// <summary>
    /// Data Transfer Object for creating a new course from client input
    /// </summary>
    public class CreateCourseRequestDto
    {
        [Required] // Field is required
        [StringLength(100)] // Maximum length of 100 characters
        public string Name { get; set; } = string.Empty; // Course name

        [Required]
        [StringLength(500)] // Max 500 characters for description
        public string Description { get; set; } = string.Empty; // Course description

        [Required]
        public IFormFile? ImageFile { get; set; } // Image file uploaded by the client (form-data)

        [Required]
        [StringLength(100)]
        public string Schedule { get; set; } = string.Empty; // Course schedule

        [Required]
        [StringLength(100)]
        public string Professor { get; set; } = string.Empty; // Professor's name
    }
}
