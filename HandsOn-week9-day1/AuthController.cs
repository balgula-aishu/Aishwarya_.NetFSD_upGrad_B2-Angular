using week9_day1.Data;
using week9_day1.Models;
using week9_day1.Services;
using Microsoft.AspNetCore.Mvc;


namespace week9_day1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly TokenService _tokenService;

        public AuthController(AppDbContext context, TokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public IActionResult Register(UserInfo user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return Ok("User Registered");
        }

        [HttpPost("login")]
        public IActionResult Login(UserInfo login)
        {
            var user = _context.Users
                .FirstOrDefault(x => x.EmailId == login.EmailId && x.Password == login.Password);

            if (user == null)
                return Unauthorized();

            var token = _tokenService.GenerateToken(user);

            return Ok(new { Token = token });
        }
    }
}
