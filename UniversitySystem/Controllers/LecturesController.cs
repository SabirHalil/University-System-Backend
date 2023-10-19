using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversitySystem.Models;

namespace UniversitySystem.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LecturesController : ControllerBase
    {
        private readonly UniversitySystemDbContext _context;

        public LecturesController(UniversitySystemDbContext context)
        {
            _context = context;
        }

        // GET: api/Lectures
        [HttpGet("{studentId}")]
        public async Task<ActionResult<IEnumerable<Lecture>>> GetLectures(int studentId)
        {
            if (!StudentExists(studentId))
            {
                return NotFound();
            }

            var chosenLectureIds = await _context.StudentLectures
                .Where(lec => lec.StudentId == studentId)
                .Select(lec => lec.LectureId)
                .ToListAsync();

            // Find all lectures that have not been chosen by the student
            var lecturesNotChosenByStudent = await _context.Lectures
                .Where(lecture => !chosenLectureIds.Contains(lecture.Id))
                .ToListAsync();

            return lecturesNotChosenByStudent;
        }


        [HttpPost]
        public async Task<ActionResult> PostLectures(List<StudentLecture> lecturesList)
        {
            if (lecturesList == null || lecturesList.Count == 0)
            {
                return BadRequest("Lectures list is null or empty.");
            }

            foreach (var lectures in lecturesList)
            {
                // Check if a lecture with the given lectureId already exists
                bool lectureExists = await _context.StudentLectures.AnyAsync(l =>l.TakenYear == lectures.TakenYear && l.LectureId == lectures.LectureId && l.StudentId == lectures.StudentId && l.SemesterId == lectures.SemesterId);

                if (lectureExists)
                {
                    return Conflict("A lecture with the provided LectureId already exists.");
                }

                _context.StudentLectures.Add(lectures);
            }

            await _context.SaveChangesAsync();

            return Ok();
        }

        // DELETE: api/Lectures/5
        private bool StudentExists(int id)
        {
            return (_context.Students?.Any(e => e.Id == id)).GetValueOrDefault();
        }

    }
}
