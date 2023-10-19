using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversitySystem.Models;

namespace UniversitySystem.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FaqController : ControllerBase
    {
        private readonly UniversitySystemDbContext _context;

        public FaqController(UniversitySystemDbContext context)
        {
            _context = context;
        }

        // GET: api/Announcements
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Faq>>> GetQuestionAnswers()
        {
            if (_context.FAQ == null)
            {
                return NotFound();
            }
            return await _context.FAQ.ToListAsync();
        }
    }
}
