using Microsoft.AspNetCore.Mvc;
using PaymentSystem;
using PaymentSystem.DAL;
using PaymentSystem.Models;
using System.Threading.Tasks;

namespace TodoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly SystemContext _context;

        public StudentController(SystemContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return student;
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudent([FromBody] Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetStudent), new { id = student.StudentId }, student);
        }
    }
}
