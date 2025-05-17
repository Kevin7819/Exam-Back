using api.Models;
using api.Dtos.Course;
using api.Mappers;
using System.Linq;

namespace api.Mappers
{
  /// <summary>
  /// Mapper class for converting between Course and CourseDto objects
  /// </summary>
  public static class CourseMapper
  {
    /// <summary>
    /// Maps a Course model to a CourseDto
    /// </summary>
    public static CourseDto ToDto(this Course course)
    {
      return new CourseDto
      {
        Id = course.Id,
        Name = course.Name,
        Description = course.Description,
        ImageUrl = course.ImageUrl,
        Schedule = course.Schedule,
        Professor = course.Professor,
        // Map the list of students to StudentDto
        Students = course.Students?.Select(s => s.ToDto()).ToList()
      };
    }

    /// <summary>
    /// Maps a CreateCourseRequestDto to a Course model
    /// </summary>
    public static Course ToCourseFromCreateDto(this CreateCourseRequestDto dto)
    {
      return new Course
      {
        Name = dto.Name,
        Description = dto.Description,
        Schedule = dto.Schedule,
        Professor = dto.Professor
        // ImageUrl is not included here because it might be set after file upload
      };
    }
  }
}
