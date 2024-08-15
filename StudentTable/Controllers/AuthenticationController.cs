using Microsoft.AspNetCore.Mvc;
using StudentTable.DTO;
using StudentTable.Model;
using StudentTable.Data;
using StudentTable.Utils;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace StudentTable.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly SchoolDbContext _context;

        public AuthenticationController(SchoolDbContext context)
        {
            _context = context;
        }

        [HttpPost("Login")]
        public async Task<ActionResult<string>> PostLogin(LoginDto loginDto)
        {
            if (loginDto == null || string.IsNullOrWhiteSpace(loginDto.UserName) || string.IsNullOrWhiteSpace(loginDto.Password))
            {
                return BadRequest("Invalid login request");
            }

            var encryptedPassword = EncryptDecrypt.Encrypt(loginDto.Password);

            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Username == loginDto.UserName && u.Password == encryptedPassword && u.IsActive);

            if (user == null)
            {
                return Unauthorized("Invalid username or password");
            }

            return Ok("Login successful");
        }
    }
}
