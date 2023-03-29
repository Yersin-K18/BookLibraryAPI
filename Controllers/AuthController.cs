using Microsoft.AspNetCore.Mvc; using Microsoft.IdentityModel.Tokens; using System.IdentityModel.Tokens.Jwt; using System.Security.Claims; using System.Text;  namespace BookLibraryAPI.Controllers {     public class AuthController : Controller     {
        private readonly IConfiguration configuration;

        public AuthController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }          public String GetToken(string id)         {             var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:SecretKey"]!));             var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256Signature);             List<Claim> Claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, id),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };              var tokenOptions = new JwtSecurityToken(                 issuer: configuration["JWT:ValidateIssuer"],                 audience: configuration["JWT:ValidAudience"],                 claims: Claims,                 expires: DateTime.Now.AddDays(7),                 signingCredentials: signinCredentials             );              return new JwtSecurityTokenHandler().WriteToken(tokenOptions);         }     } } 