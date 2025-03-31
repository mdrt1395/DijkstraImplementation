//using DijkstraImplementation.Services;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace DijkstraImplementation.Controllers
//{
//    [Route("api/[controller]/[action]")]
//    [ApiController]
//    public class AuthController : ControllerBase
//    {
//        private readonly JwtService _jwtService = new JwtService();
//        [HttpPost]
//        public IActionResult Login([FromBody] LoginInfo loginInfo)
//        {
//            if (loginInfo.Username == "Admin" && loginInfo.Password == "Password1!")
//            {
//                var token = _jwtService.GenerateToken(loginInfo.Username);
//                return Ok(new { Token = token });
//            }
//            return Unauthorized();
//        }

//        [Authorize]
//        [HttpGet]
//        public IActionResult getSecuredData()
//        {
//            return Ok("This is the protected method data");
//        }
//    }

//    public class LoginInfo
//    {
//        public string Username { get; set; }
//        public string Password { get; set; }

//    }
//}