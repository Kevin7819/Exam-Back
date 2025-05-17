using System.ComponentModel.DataAnnotations;

namespace api.Dtos.Student
{
  /// <summary>
  /// Data Transfer Object for creating a new student
  /// </summary>
  public class CreateStudentRequestDto
  {
    [Required] // Name is required
    [StringLength(100)] // Max 100 characters
    public string Name { get; set; }

    [Required] // Email is required
    [EmailAddress] // Must be a valid email format
    public string Email { get; set; }

    [Required] // Phone is required
    [Phone] // Must be a valid phone number
    public string Phone { get; set; }

    [Required] // Associated course ID is required
    public int CourseId { get; set; }
  }
}
