using Microsoft.AspNetCore.Mvc;
using webapiproject.Models;

namespace webapiproject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        // ✅ GET ALL
        [HttpGet]
        public ActionResult<IEnumerable<Student>> GetStudents()
        {
            return Ok(classRepositary.Students);
        }

        // ✅ GET BY ID
        [HttpGet("{id:int}", Name = "GetStudent")]
        public ActionResult<Student> GetStudent(int id)
        {
            if (id <= 0)
                return BadRequest();

            var student = classRepositary.Students.FirstOrDefault(n => n.id == id);

            if (student == null)
                return NotFound();

            return Ok(student);
        }

        // ✅ GET BY NAME
        [HttpGet("{name:alpha}", Name = "GetStudentByName")]
        public ActionResult<Student> GetStudentName(string name)
        {
            if (string.IsNullOrEmpty(name))
                return BadRequest();

            var student = classRepositary.Students
                .FirstOrDefault(n => n.name.ToLower() == name.ToLower());

            if (student == null)
                return NotFound();

            return Ok(student);
        }

        // ✅ DELETE
        [HttpDelete("{id:int}", Name = "DeleteStudent")]
        public ActionResult<bool> DeleteStudent(int id)
        {
            if (id <= 0)
                return BadRequest();

            var student = classRepositary.Students
                .FirstOrDefault(n => n.id == id);

            if (student == null)
                return NotFound($"Student not found with id {id}");

            classRepositary.Students.Remove(student);

            return Ok(true);
        }

        // ✅ CREATE (POST)
        [HttpPost("create")]
        public ActionResult<Student> CreateDetails(Student student)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            int newId = classRepositary.Students.Any()
                ? classRepositary.Students.Max(s => s.id) + 1
                : 1;

            var newStudent = new Student
            {
                id = newId,
                name = student.name,
                age = student.age
            };

            classRepositary.Students.Add(newStudent);

            return CreatedAtRoute("GetStudent",new { id = newStudent.id },newStudent);
        }

        // ✅ UPDATE (PUT)  ⭐ (added for your requirement)
        [HttpPut("{id:int}")]
        public ActionResult<Student> UpdateStudent(int id, Student updatedStudent)
        {
            if (id <= 0 || updatedStudent == null)
                return BadRequest();

            var existingStudent = classRepositary.Students.FirstOrDefault(n => n.id == id);

            if (existingStudent == null)
                return NotFound();

            existingStudent.name = updatedStudent.name;
            existingStudent.age = updatedStudent.age;

            return Ok(existingStudent);
        }
    }
}