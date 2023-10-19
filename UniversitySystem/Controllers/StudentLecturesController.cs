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
    public class StudentLecturesController : ControllerBase
    {
        private readonly UniversitySystemDbContext _context;

        public StudentLecturesController(UniversitySystemDbContext context)
        {
            _context = context;
        }

        // GET: api/StudentLectures
        [HttpGet("{studentId}")]
        public async Task<ActionResult<IEnumerable<StudentLectureDTO>>> GetStudentLectures(int studentId)
        {
            if (!StudentExists(studentId))
            {
                return NotFound();
            }
            var studentLectures = await _context.StudentLectureView.Where(s => s.StudentId == studentId).ToListAsync();

            if(studentLectures.Count > 0)
                return Ok(studentLectures);

            return BadRequest(); 
        }

        [HttpDelete("{studentId}/{lectureId}")]
        public async Task<IActionResult> DeleteLecture(int studentId, int lectureId)
        {
            var lecture = await _context.StudentLectures
                .SingleOrDefaultAsync(l => l.StudentId == studentId && l.Id == lectureId);

            if (lecture == null)
            {
                return NotFound();
            }

            _context.StudentLectures.Remove(lecture);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        private bool StudentExists(int id)
        {
            return (_context.Students?.Any(e => e.Id == id)).GetValueOrDefault();
        }

    }
}
