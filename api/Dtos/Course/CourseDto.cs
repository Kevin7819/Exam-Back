using System.Collections.Generic;
using api.Dtos.Student;

namespace api.Dtos.Course
{
  /// <summary>
  /// Data Transfer Object for sending course details to the client
  /// </summary>
  public class CourseDto
  {
    public int Id { get; set; }                      // Unique identifier for the course
    public string Name { get; set; }                 // Course name
    public string Description { get; set; }          // Detailed description of the course
    public string? ImageUrl { get; set; }            // URL of the image representing the course (optional)
    public string Schedule { get; set; }             // Schedule or timing of the course
    public string Professor { get; set; }            // Name of the professor teaching the course

    public List<StudentDto> Students { get; set; }   // List of students enrolled in the course
  }
}
