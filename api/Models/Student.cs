namespace api.Models
{
  /// <summary>
  /// Entity model representing a Student
  /// </summary>
  public class Student
  {
    public int Id { get; set; } // Unique identifier
    public string Name { get; set; } // Student's name
    public string Email { get; set; } // Student's email address
    public string Phone { get; set; } // Student's phone number

    public int CourseId { get; set; } // Foreign key to associated course
    public Course Course { get; set; } // Navigation property to Course
  }
}
