using Microsoft.AspNetCore.Mvc;
using webapiproject.Models;

namespace webapiproject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly AppDbContext _context;

        public StudentController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/student
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_context.Students.ToList());
        }

        // GET: api/student/{id}
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var student = _context.Students.Find(id);
            if (student == null)
                return NotFound();

            return Ok(student);
        }

        // POST: api/student
        [HttpPost]
        public IActionResult Create(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
            return Ok(student);
        }

        // PUT: api/student/{id}
        [HttpPut("{id}")]
        public IActionResult Update(int id, Student student)
        {
            var existing = _context.Students.Find(id);
            if (existing == null)
                return NotFound();

            existing.Name = student.Name;
            existing.Age = student.Age;

            _context.SaveChanges();

            return Ok(existing);
        }

        // DELETE: api/student/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var student = _context.Students.Find(id);
            if (student == null)
                return NotFound();

            _context.Students.Remove(student);
            _context.SaveChanges();

            return Ok("Deleted Successfully");
        }
    }
}