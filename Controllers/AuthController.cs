using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BookLibraryAPI.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult GetToken()
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("your_jwt_secret_key"));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var tokenOptions = new JwtSecurityToken(
                issuer: "http://localhost:55363",
                audience: "http://localhost:55363",
                claims: new List<Claim>(),
                expires: DateTime.Now.AddDays(7),
                signingCredentials: signinCredentials
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            return Ok(new { Token = tokenString });
        }
    }
}
