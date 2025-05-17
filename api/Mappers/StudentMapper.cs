using api.Models;
using api.Dtos.Student;

namespace api.Mappers
{
  /// <summary>
  /// Mapper class for converting between Student and StudentDto objects
  /// </summary>
  public static class StudentMapper
  {
    /// <summary>
    /// Maps a Student model to a StudentDto
    /// </summary>
    public static StudentDto ToDto(this Student student)
    {
      return new StudentDto
      {
        Id = student.Id,
        Name = student.Name,
        Email = student.Email,
        Phone = student.Phone
      };
    }

    /// <summary>
    /// Maps a CreateStudentRequestDto to a Student model
    /// </summary>
    public static Student ToStudentFromCreateDto(this CreateStudentRequestDto dto)
    {
      return new Student
      {
        Name = dto.Name,
        Email = dto.Email,
        Phone = dto.Phone,
        CourseId = dto.CourseId
      };
    }
  }
}
