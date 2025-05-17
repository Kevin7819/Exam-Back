using System.ComponentModel.DataAnnotations;

namespace api.Dtos.Student
{
  /// <summary>
  /// Data Transfer Object for updating an existing student
  /// </summary>
  public class UpdateStudentRequestDto
  {
    [Required] // Name is required
    [StringLength(100)] // Max 100 characters
    public string Name { get; set; }

    [Required] // Email is required
    [EmailAddress] // Must be a valid email address
    public string Email { get; set; }

    [Required] // Phone is required
    [Phone] // Must be a valid phone number
    public string Phone { get; set; }

    [Required] // Updated course ID is required
    public int CourseId { get; set; }
  }
}
