using Microsoft.AspNetCore.Mvc;
using StudentTable.Data;
using StudentTable.DTO;
using StudentTable.Model;
using StudentTable.Utils;
using System.Threading.Tasks;

namespace StudentTable.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly SchoolDbContext _context;

        public UsersController(SchoolDbContext context)
        {
            _context = context;
        }

        [HttpPost("AddUser")]
        public async Task<ActionResult<CreateUsersDto>> AddUsersDtoAsync(CreateUsersDto createUsersDto)
        {
            if (createUsersDto == null)
            {
                return BadRequest("User data is null");
            }

            var encryptedPassword = EncryptDecrypt.Encrypt(createUsersDto.Password);

            var user = new Users
            {
                Username = createUsersDto.UsersName,
                Password = encryptedPassword,
                Email = createUsersDto.Email,
                IsActive = true,
                Status = "Active",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return Ok(createUsersDto);
        }
    }
}
