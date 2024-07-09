using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentRegistrationWebAPIWithInMemory.Data;
using StudentRegistrationWebAPIWithInMemory.Models;

namespace StudentRegistrationWebAPIWithInMemory.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : Controller
    {
        private readonly ApplicationAPIDbContext _dbcontext;
        public StudentsController(ApplicationAPIDbContext dbContext)
        {
            _dbcontext = dbContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            return Ok(await _dbcontext.Students2.ToListAsync());
        }
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetStudent([FromRoute] Guid id)
        {
            var student = await _dbcontext.Students2.FindAsync(id);
            if (student == null)
            {
               return NotFound();
            }
             return Ok(student);
        }
        [HttpPost]
        public async Task<IActionResult> AddStudent(AddStudentView addStudentView)
        {
            var student = new Student()
            {
                Id = Guid.NewGuid(),
                Name = addStudentView.Name,
                Surname = addStudentView.Surname,
                Email = addStudentView.Email,
                PhoneNumber = addStudentView.PhoneNumber,
                StudentId = Guid.NewGuid(),
                DateOfBirth = DateTime.Now
            };
            await _dbcontext.Students2.AddAsync(student);
            await _dbcontext.SaveChangesAsync();

            return Ok(student);


        }
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateStudent([FromRoute] Guid id, UpdateStudentView updateStudentView)
        {
          var student = await _dbcontext.Students2.FindAsync(id);

            if (student != null)
            {
                student.Name = updateStudentView.Name;
                student.Surname = updateStudentView.Surname;
                student.Email = updateStudentView.Email;
                student.PhoneNumber = updateStudentView.PhoneNumber;
                student.DateOfBirth = DateTime.Now;

                await _dbcontext.SaveChangesAsync();
                return Ok(student);
            }

            return NotFound();
        }
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteStudent([FromRoute] Guid id)
        {
          var student = await _dbcontext.Students2.FindAsync(id);
            if (student != null)
            {
                _dbcontext.Remove(student);
                await _dbcontext.SaveChangesAsync();
                return Ok(student);
            }
            return NotFound();
        }

    }
}
