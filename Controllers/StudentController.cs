using Microsoft.AspNetCore.Mvc;
using MongoDBDemo.Models;
using MongoDBDemo.Services;

namespace MongoDBDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly StudentService _studentService;

        public StudentController(StudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<List<Student>> GetAll() =>
            await _studentService.GetAllAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetById(string id)
        {
            var student = await _studentService.GetByIdAsync(id);
            return student is null ? NotFound() : Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Student student)
        {
            await _studentService.CreateAsync(student);
            return CreatedAtAction(nameof(GetById), new { id = student.Id }, student);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, Student student)
        {
            var existing = await _studentService.GetByIdAsync(id);
            if (existing is null) return NotFound();
            await _studentService.UpdateAsync(id, student);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var existing = await _studentService.GetByIdAsync(id);
            if (existing is null) return NotFound();
            await _studentService.DeleteAsync(id);
            return NoContent();
        }
    }
}