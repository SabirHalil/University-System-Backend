using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversitySystem.Models;
using UniversitySystem.Models.DTOs;

namespace UniversitySystem.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly UniversitySystemDbContext _context;

        public StudentsController(UniversitySystemDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudentInfo(int studentId)
        {
            var student = await _context.StudentInfo.SingleOrDefaultAsync(s => s.Id == studentId);
            if (student == null) { return NotFound(); }
            return Ok(student);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudentCertification(int id)
        {
            var student = await _context.StudentCertification.SingleOrDefaultAsync(s => s.Id == id);
            if (student == null) { return NotFound(); }
            return Ok(student);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent(int id, StudentUpdatableAttributes student)
        {
         
            var userId = await _context.Students.Where(u=> u.Id == id).Select(u => u.UserId).FirstOrDefaultAsync();

            if (userId == 0)
            {
                return NotFound();
            }
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Id == id);

            // Update only the fields that are provided in the request
            if (student.Address != "")
            {
                user.Address = student.Address;
            }
                if (student.Phone != "")
            {
                user.Phone = student.Phone;
            }
            
                  if (student.Iban != "")
                    {
                    var existingUserIban = await _context.UserIbans.FirstOrDefaultAsync(iban => iban.Id == userId);
                    if (existingUserIban == null)
                     {

                // If the UserIban doesn't exist, create a new row in the UserIban table
                var newUserIban = new UserIban
                {
                    Id = id,
                    Iban = student.Iban
                };

                _context.UserIbans.Add(newUserIban);
            }
            else
            {
                // If the UserIban exists, update it if the UserIban property is provided in the request
               
                    existingUserIban.Iban = student.Iban;
                }
            }

            try
            {
                _context.Entry(user).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        private bool StudentExists(int id)
        {
            return (_context.Users?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
