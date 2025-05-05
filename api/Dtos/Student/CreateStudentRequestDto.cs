using System.ComponentModel.DataAnnotations;

namespace api.Dtos.Student
{
  public class CreateStudentRequestDto
  {
    [Required]
    [StringLength(100)]
    public string Name { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Phone]
    public string Phone { get; set; }

    [Required]
    public int CourseId { get; set; }
  }
}
