using api.Models;
using api.Dtos.Course;
using api.Mappers;
using System.Linq;

namespace api.Mappers
{
  public static class CourseMapper
  {
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
        Students = course.Students?.Select(s => s.ToDto()).ToList()
      };
    }

    public static Course ToCourseFromCreateDto(this CreateCourseRequestDto dto)
    {
      return new Course
      {
        Name = dto.Name,
        Description = dto.Description,
        ImageUrl = dto.ImageUrl,
        Schedule = dto.Schedule,
        Professor = dto.Professor
      };
    }
  }
}
