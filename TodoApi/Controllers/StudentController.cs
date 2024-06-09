﻿using Microsoft.AspNetCore.Mvc;
using PaymentSystem.Models;
using System.Threading.Tasks;
using WebApi.Models;
using WebApi.Extension;
using PaymentSystem;
using Microsoft.EntityFrameworkCore;

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

        // POST: api/Student
        [HttpPost]
        public async Task<ActionResult<Student>> PostStudent(StudentDTO studentDTO)
        {
            // Convert DTO to DAL model
            Student student = studentDTO.ToDAL();

            // Debugging output
            Console.WriteLine("Received StudentDTO:");
            Console.WriteLine("StudentID: " + studentDTO.StudentId);  // This should be null or 0
            Console.WriteLine("Firstname: " + studentDTO.Firstname);
            Console.WriteLine("Lastname: " + studentDTO.Lastname);
            Console.WriteLine("Username: " + studentDTO.Username);

            // Add the new student to the context
            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            // Convert back to DTO to return
            var studentToReturn = student.ToModel();

            return CreatedAtAction(nameof(GetStudent), new { id = student.StudentId }, studentToReturn);
        }

        // GET: api/Student/{id}
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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetAllStudents()
        {

            var ListOfStudents = await _context.Students.ToListAsync();
            List<StudentDTO> ListOfStudentDTO = new List<StudentDTO>();
            foreach (var student in ListOfStudents)
            {
                StudentDTO studentDTO = new StudentDTO();
                studentDTO = student.ToModel();
                ListOfStudentDTO.Add(studentDTO);
            }
            return Ok(ListOfStudentDTO);
        }
    }
}
