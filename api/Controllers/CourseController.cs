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
        private readonly string _imagePath = Path.Combine(Directory.GetCurrentDirectory(), "UploadedImages");
        private readonly ILogger<CourseController> _logger;

        public CourseController(AppDbContext context, ILogger<CourseController> logger)
        {
            _context = context;
            _logger = logger;
            
            // Ensure the image directory exists
            Directory.CreateDirectory(_imagePath);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var courses = await _context.Courses
                    .Include(c => c.Students)
                    .ToListAsync();
                
                return Ok(courses.Select(c => c.ToDto()));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting all courses");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var course = await _context.Courses
                    .Include(c => c.Students)
                    .FirstOrDefaultAsync(c => c.Id == id);
                
                return course == null ? NotFound() : Ok(course.ToDto());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error getting course with id {id}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateCourseRequestDto dto)
        {
            try
            {
                if (dto.ImageFile == null || dto.ImageFile.Length == 0)
                    return BadRequest("Image file is required");

                // Validate file type and size
                var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
                var fileExtension = Path.GetExtension(dto.ImageFile.FileName).ToLowerInvariant();
                
                if (!allowedExtensions.Contains(fileExtension))
                    return BadRequest("Invalid file type. Only image files are allowed.");

                if (dto.ImageFile.Length > 5 * 1024 * 1024) // 5MB
                    return BadRequest("File size exceeds the 5MB limit.");

                var model = dto.ToCourseFromCreateDto();
                await _context.Courses.AddAsync(model);
                await _context.SaveChangesAsync();

                // Save the image file
                var fileName = $"{model.Id}{fileExtension}";
                var filePath = Path.Combine(_imagePath, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await dto.ImageFile.CopyToAsync(stream);
                }

                // Update the course with the image filename
                model.ImageUrl = $"/UploadedImages/{fileName}";
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetById), new { id = model.Id }, model.ToDto());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating course");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateCourseRequestDto dto)
        {
            try
            {
                var model = await _context.Courses.FindAsync(id);
                if (model == null) 
                    return NotFound();

                model.Name = dto.Name;
                model.Description = dto.Description;
                model.Schedule = dto.Schedule;
                model.Professor = dto.Professor;

                // Only update ImageUrl if it's provided
                if (!string.IsNullOrEmpty(dto.ImageUrl))
                    model.ImageUrl = dto.ImageUrl;

                await _context.SaveChangesAsync();
                return Ok(model.ToDto());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error updating course with id {id}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var model = await _context.Courses.FindAsync(id);
                if (model == null) 
                    return NotFound();

                // Delete the associated image file if it exists
                if (!string.IsNullOrEmpty(model.ImageUrl))
                {
                    var fileName = Path.GetFileName(model.ImageUrl);
                    var filePath = Path.Combine(_imagePath, fileName);
                    
                    if (System.IO.File.Exists(filePath))
                    {
                        System.IO.File.Delete(filePath);
                    }
                }

                _context.Courses.Remove(model);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error deleting course with id {id}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}