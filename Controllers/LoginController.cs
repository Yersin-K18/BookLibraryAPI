using Microsoft.AspNetCore.Mvc;

namespace BookLibraryAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly AuthController authController;
        public LoginController(IConfiguration configuration)
        {
            authController = new AuthController(configuration);
        }

        [HttpPost]
        public IActionResult Login(string id, string password)
        {
            if (id == "admin" && password == "1")
            {
                return Ok(authController.GetToken(id));
            }
            return Ok(new
            {
                Message = "Invalid username/password"
            });
        }
    }
}
