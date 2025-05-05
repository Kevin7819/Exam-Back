using api.Data;
using api.Dtos.Course;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
  [ApiController]
  [Route("api/courses")]
  public class CourseController : ControllerBase
  {
    private readonly AppDbContext _context;

    public CourseController(AppDbContext context)
    {
      _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
      var courses = await _context.Courses.Include(c => c.Students).ToListAsync();
      return Ok(courses.Select(c => c.ToDto()));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
      var course = await _context.Courses.Include(c => c.Students).FirstOrDefaultAsync(c => c.Id == id);
      return course == null ? NotFound() : Ok(course.ToDto());
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCourseRequestDto dto)
    {
      var model = dto.ToCourseFromCreateDto();
      await _context.Courses.AddAsync(model);
      await _context.SaveChangesAsync();
      return CreatedAtAction(nameof(GetById), new { id = model.Id }, model.ToDto());
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateCourseRequestDto dto)
    {
      var model = await _context.Courses.FindAsync(id);
      if (model == null) return NotFound();

      model.Name = dto.Name;
      model.Description = dto.Description;
      model.ImageUrl = dto.ImageUrl;
      model.Schedule = dto.Schedule;
      model.Professor = dto.Professor;

      await _context.SaveChangesAsync();
      return Ok(model.ToDto());
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
      var model = await _context.Courses.FindAsync(id);
      if (model == null) return NotFound();

      _context.Courses.Remove(model);
      await _context.SaveChangesAsync();
      return NoContent();
    }
  }
}
