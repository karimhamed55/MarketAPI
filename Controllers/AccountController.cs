using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using webAPI.Model;
using webAPI.data;
using webAPI.DTO;

namespace webAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private readonly MarketDbContext _context;
        private readonly IConfiguration _configuration;

        public AccountController(MarketDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpPost("Register")]

        public async Task<ActionResult<User>> Register ([FromBody]UserRegisterDto request)
        {
            var user = new User
            {
                Name = request.Username,
                Email = request.Email,
                Password = request.Password
            };
            _context.Add(user);
            if (request == null) return BadRequest("Request body is null");
            await _context.SaveChangesAsync();

            return Ok(user);
           
        }

        [HttpPost("Login")]

        public async Task<ActionResult<string>> Login ([FromBody]UserLoginDto request)
        {
            var user = _context.Users.FirstOrDefault(u => u.Name == request.Username);

            if (user == null || user.Password != request.Password)
            {
                return BadRequest("Wrong username or password.");
            }

            string token = CreateToken(user);
            return Ok(token);

        }

        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.Name),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Role, user.Role)

        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
            );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }


    }
}
