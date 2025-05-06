using api.Data;
using api.Dtos.Student;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
  [ApiController]
  [Route("api/students")]
  public class StudentController : ControllerBase
  {
    private readonly AppDbContext _context;

    public StudentController(AppDbContext context)
    {
      _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateStudentRequestDto dto)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      var course = await _context.Courses.FindAsync(dto.CourseId);
      if (course == null)
        return BadRequest("El curso no existe");

      var student = dto.ToStudentFromCreateDto();
      await _context.Students.AddAsync(student);
      await _context.SaveChangesAsync();

      return CreatedAtAction(nameof(GetById), new { id = student.Id }, student.ToDto());
    }

    [HttpGet("byCourse/{courseId}")]
    public async Task<IActionResult> GetByCourse(int courseId)
    {
      var students = await _context.Students
        .Where(s => s.CourseId == courseId)
        .ToListAsync();

      return Ok(students.Select(s => s.ToDto()));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
      var student = await _context.Students.FindAsync(id);
      if (student == null) return NotFound("Estudiante no encontrado");

      return Ok(student.ToDto());
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateStudentRequestDto dto)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      var student = await _context.Students.FindAsync(id);
      if (student == null) return NotFound("Estudiante no encontrado");

      var course = await _context.Courses.FindAsync(dto.CourseId);
      if (course == null) return BadRequest("El curso no existe");

      student.Name = dto.Name;
      student.Email = dto.Email;
      student.Phone = dto.Phone;
      student.CourseId = dto.CourseId;

      await _context.SaveChangesAsync();
      return Ok(student.ToDto());
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
      var student = await _context.Students.FindAsync(id);
      if (student == null)
        return NotFound("Estudiante no encontrado");

      _context.Students.Remove(student);
      await _context.SaveChangesAsync();

      return Ok("Estudiante eliminado correctamente");
    }
  }
}
