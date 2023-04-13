using BookLibraryAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BookLibraryAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IConfiguration configuration;

        public AuthController(IConfiguration configuration, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.configuration = configuration;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        private String GetToken(string id)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:SecretKey"]!));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256Signature);
            List<Claim> Claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, id),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var tokenOptions = new JwtSecurityToken(
                issuer: configuration["JWT:ValidateIssuer"],
                audience: configuration["JWT:ValidAudience"],
                claims: Claims,
                expires: DateTime.Now.AddDays(7),
                signingCredentials: signinCredentials
            );

            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(string username, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(username, password, false, false);

            if (!result.Succeeded)
            {
                return BadRequest(new { message = "Invalid username or password" });
            }

            return Ok(new
            {
                message = "Halo " + username,
                token = this.GetToken(username)
            });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Create a new IdentityUser with the given email and username
                var user = new IdentityUser { UserName = model.UserName, Email = model.Email };

                // Create the user in the database
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    // Return a success response
                    return Ok(new { message = "User created successfully." });
                }

                // If there are errors, return a BadRequest response with the errors
                var errors = result.Errors.Select(e => e.Description);
                return BadRequest(new { errors });
            }

            // If the ModelState is invalid, return a BadRequest response with the errors
            var modelErrors = ModelState.Values.SelectMany(v => v.Errors)
                                                .Select(e => e.ErrorMessage);
            return BadRequest(new { errors = modelErrors });
        }
    }
}
