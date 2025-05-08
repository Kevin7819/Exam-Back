using System.ComponentModel.DataAnnotations;

namespace api.Dtos.Student
{
  public class CreateStudentRequestDto
  {
    [Required]
    [StringLength(100)]
    public string Name { get; set; }

    [Required]
    [StringLength(100)]
    public string Email { get; set; }

    [Required]
    [StringLength(100)]
    public string Phone { get; set; }

    [Required]
    public int CourseId { get; set; }
  }
}
