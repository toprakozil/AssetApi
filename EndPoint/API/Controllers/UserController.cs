using Application.Models.User;
using Application.Services.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IConfiguration _config;
        private readonly IUserService _userService;

        public UserController(IConfiguration config, IUserService userService)
        {
            _config = config;
            _userService = userService;
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginUserPayload request)
        {

            if (_userService.CanLogin(request))
            {
                var tokenString = GenerateJSONWebToken(request.UserName);
                return Ok(new { token = tokenString });
            }
            else
                return StatusCode(401);

        }

        [HttpGet("GetByCount")]
        [Authorize]
        public IActionResult GetAll([FromQuery] int count, bool enableCache)
        {
            var result = _userService.GetUsersByCount(count,enableCache);
            return Ok(result);
        }

        [HttpPost("Register")]
        //TODO [Authorize]
        public IActionResult Register([FromBody] AddUserPayload request)
        {
            _userService.Register(request, getCurrentUser());
            return StatusCode(201);
        }

        [HttpDelete("Delete")]
        [Authorize]
        public IActionResult Delete([FromQuery] long Id)
        {
            var result = _userService.Delete(Id, getCurrentUser());
            return Ok(result);
        }

        #region Helpers 
        private string GenerateJSONWebToken(string userName)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {

                new Claim(JwtRegisteredClaimNames.NameId, userName),
                new Claim(JwtRegisteredClaimNames.UniqueName, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        private string? getCurrentUser()
        {
            if (HttpContext.User.Claims.Any())
                return HttpContext.User.Claims.First().Value;
            return null;
        }
        #endregion

    }
}
