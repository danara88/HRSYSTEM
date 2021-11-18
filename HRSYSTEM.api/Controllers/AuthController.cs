using HRSYSTEM.domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HRSYSTEM.api.Controllers
{
    /// <summary>
    /// This is the auth controller to manage auth actions
    /// </summary>
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IConfiguration _configuration;

        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        [Route("~/api/auth/login")]
        public string Login()
        {
            UserEntity userEntity = new UserEntity()
            {
                UserID = 1,
                Name = "Daniel",
                Surname = "Aranda",
                Username = "daniel88",
                Email = "daniel@hotmail.com",
                Password="1234"
            };
            var token = BuildToken(userEntity);

            return token;
        }

        private string BuildToken(UserEntity usuario)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Auth:Jwt:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, usuario.Surname)
            };
            var token = new JwtSecurityToken(_configuration["Auth:Jwt:Issuer"],
                                             _configuration["Auth:Jwt:Audience"],
                                             claims,
                                             expires: DateTime.Now.AddMinutes(Convert.ToDouble(_configuration["Auth:Jwt:TokenExpirationInMinutes"])),
                                             signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
