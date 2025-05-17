using System.Collections.Generic;

namespace api.Models
{
  /// <summary>
  /// Entity model representing a Course
  /// </summary>
  public class Course
  {
    public int Id { get; set; } // Unique identifier
    public string Name { get; set; } // Name of the course
    public string Description { get; set; } // Description of the course
    public string? ImageUrl { get; set; } // image URL
    public string Schedule { get; set; } // Course schedule
    public string Professor { get; set; } // Name of the professor/instructor

    // Navigation property - list of students enrolled in the course
    public ICollection<Student> Students { get; set; }
  }
}
