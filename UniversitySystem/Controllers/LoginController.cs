using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using UniversitySystem.Models;

namespace UniversitySystem.Controllers
{
    [Route("auth/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        IConfiguration _configuration;
        private readonly UniversitySystemDbContext _context;

        public LoginController(UniversitySystemDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public string HashPassword(string password)
        {
            
            string salt = BCrypt.Net.BCrypt.GenerateSalt(12); 
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password, salt);

            return hashedPassword;
        }
        private User GetAuthenticatedUser(long IDCard, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.IdCard == IDCard);

            if (user != null && BCrypt.Net.BCrypt.Verify(password, user.HashedPassword))
            {
            return user;
            }

            return null;
        }

        private string GenerateToken()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"], null,
                expires: DateTime.UtcNow.AddDays(7),
                signingCredentials: credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] LoginBody body)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            IActionResult response = Unauthorized();
            var user = GetAuthenticatedUser(body.CardId, body.Password);
            
            if (user != null)
            {
                int studentId = getStudentIdByUserId(user.Id);
                var token = GenerateToken();
                response = Ok(new { token = token, studentId = studentId });
            }

            return response;
        }
        private int getStudentIdByUserId(int userId)
        {
            var studentId = _context.Students.Where(s => s.UserId == userId).Select(s => s.Id).SingleOrDefault();
            return studentId;
        }

        private int getUserIdByStudentId(int studentId)
        {
            var userId = _context.Students.Where(s=> s.Id == studentId).Select(s => s.UserId).SingleOrDefault();
            return userId;
        }

        [HttpPost("change_password")]
          public IActionResult ChangePassword([FromBody] ChangePasswordBody body)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            int userId = getUserIdByStudentId(body.StudentId);
            var user = _context.Users.Where(u=> u.Id == userId).SingleOrDefault();
            if (user != null)
            {
                if(BCrypt.Net.BCrypt.Verify(body.OldPassword, user.HashedPassword))
                {
                    user.HashedPassword = HashPassword(body.NewPassword);
                    _context.SaveChanges();
                    return Ok();
                }
            }
            return BadRequest(ModelState);
        }

    }
}
