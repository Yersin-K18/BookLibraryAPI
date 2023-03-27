using Microsoft.AspNetCore.Mvc; using Microsoft.IdentityModel.Tokens; using System.IdentityModel.Tokens.Jwt; using System.Security.Claims; using System.Text;  namespace BookLibraryAPI.Controllers {     public class AuthController : Controller     {
        private readonly IConfiguration configuration;

        public AuthController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }          public String GetToken(string id)         {             var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:SecretKey"]!));             var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256Signature);              var tokenOptions = new JwtSecurityToken(                 issuer: configuration["JWT:ValidateIssuer"],                 audience: configuration["JWT:ValidAudience"],                 claims: new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, id),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                },                 expires: DateTime.Now.AddDays(7),                 signingCredentials: signinCredentials             );              string tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);             return tokenString;         }     } } 