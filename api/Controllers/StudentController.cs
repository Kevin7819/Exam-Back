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

    // POST: api/students
    // Creates a new student after validating uniqueness of name, email, and phone
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateStudentRequestDto dto)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      // Check if the course exists
      var course = await _context.Courses.FindAsync(dto.CourseId);
      if (course == null)
        return BadRequest("Course does not exist");

      // Validate uniqueness of name, email, and phone
      var conflict = await _context.Students.AnyAsync(s =>
        s.Name.ToLower() == dto.Name.ToLower() ||
        s.Email.ToLower() == dto.Email.ToLower() ||
        s.Phone == dto.Phone
      );

      if (conflict)
        return BadRequest("A student with the same name, email, or phone already exists");

      // Create and save the new student
      var student = dto.ToStudentFromCreateDto();
      await _context.Students.AddAsync(student);
      await _context.SaveChangesAsync();

      return CreatedAtAction(nameof(GetById), new { id = student.Id }, student.ToDto());
    }

    // GET: api/students/byCourse/{courseId}
    // Returns all students in a specific course
    [HttpGet("byCourse/{courseId}")]
    public async Task<IActionResult> GetByCourse(int courseId)
    {
      var students = await _context.Students
        .Where(s => s.CourseId == courseId)
        .ToListAsync();

      return Ok(students.Select(s => s.ToDto()));
    }

    // GET: api/students/{id}
    // Returns a single student by ID
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
      var student = await _context.Students.FindAsync(id);
      if (student == null) return NotFound("Student not found");

      return Ok(student.ToDto());
    }

    // PUT: api/students/{id}
    // Updates a student after validating uniqueness of name, email, and phone
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateStudentRequestDto dto)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      // Find student by ID
      var student = await _context.Students.FindAsync(id);
      if (student == null) return NotFound("Student not found");

      // Check if the course exists
      var course = await _context.Courses.FindAsync(dto.CourseId);
      if (course == null) return BadRequest("Course does not exist");

      // Validate uniqueness of name, email, and phone (excluding current student)
      var conflict = await _context.Students.AnyAsync(s =>
        s.Id != id &&
        (
          s.Name.ToLower() == dto.Name.ToLower() ||
          s.Email.ToLower() == dto.Email.ToLower() ||
          s.Phone == dto.Phone
        )
      );

      if (conflict)
        return BadRequest("Another student with the same name, email, or phone already exists");

      // Update student properties
      student.Name = dto.Name;
      student.Email = dto.Email;
      student.Phone = dto.Phone;
      student.CourseId = dto.CourseId;

      await _context.SaveChangesAsync();
      return Ok(student.ToDto());
    }

    // DELETE: api/students/{id}
    // Deletes a student by ID
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
      var student = await _context.Students.FindAsync(id);
      if (student == null)
        return NotFound("Student not found");

      _context.Students.Remove(student);
      await _context.SaveChangesAsync();

      return Ok("Student deleted successfully");
    }
  }
}
