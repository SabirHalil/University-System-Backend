using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversitySystem.Models;

namespace UniversitySystem.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly UniversitySystemDbContext _context;

        public NotificationsController(UniversitySystemDbContext context)
        {
            _context = context;
        }

        // GET: api/Notifications/5
        [HttpGet("{studentId}")]
        public async Task<ActionResult<IEnumerable<Notification>>> GetNotification(int studentId)
        {
          if (_context.Notifications == null)
          {
              return NotFound();
          }
            var notification = await _context.Notifications.Where(n => n.StudentId == studentId).ToListAsync();

            if (notification == null)
            {
                return NotFound();
            }

            return notification;
        }
    }
}
