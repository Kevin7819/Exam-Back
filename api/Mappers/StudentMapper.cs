using api.Models;
using api.Dtos.Student;

namespace api.Mappers
{
  public static class StudentMapper
  {
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
