using Microsoft.AspNetCore.Mvc;
using PaymentSystem;
using Microsoft.EntityFrameworkCore;
using PaymentSystem.Models;
using System.Threading.Tasks;
using WebApi.Models;
using WebApi.Extension;

namespace TodoApi.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly SystemContext _context;

        public StudentController(SystemContext context)
        {
            _context = context;
        }

        // PUT: api/addStudent

        [HttpPost]
    public async Task<ActionResult<Student>> PostStudent(StudentDTO studentDTO)
        {
            Student student = studentDTO.ToDAL();

            Console.WriteLine("ID" + student.StudentId + " FirstName" + student.Firstname +
                "LastName" + student.Lastname + " Username" + student.Lastname);
            _context.Students.Add(student);

            var student2 = student.ToModel();

            return CreatedAtAction(nameof(GetStudent), new {id = student.StudentId},student2);

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
            try
            {
                _context.Students.Add(student);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetStudent), new { id = student.StudentId }, student);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while creating the student.");
            }
        }
    }
}
