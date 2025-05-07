using System.ComponentModel.DataAnnotations;

namespace api.Dtos.Course
{
  public class CreateCourseRequestDto
  {
    [Required]
    [StringLength(100)]
    public string Name { get; set; }

    [Required]
    [StringLength(500)]
    public string Description { get; set; }

    [Required]
    [StringLength(100)]
    public string ImageUrl { get; set; }

    [Required]
    [StringLength(100)]
    public string Schedule { get; set; }

    [Required]
    [StringLength(100)]
    public string Professor { get; set; }
  }
}
