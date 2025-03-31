//using System.IdentityModel.Tokens.Jwt;
//using System.Security.Claims;
//using System.Text;
//using Azure.Core.Pipeline;
//using DijkstraImplementation.Models.Entities;
//using Microsoft.IdentityModel.JsonWebTokens;
//using Microsoft.IdentityModel.Tokens;
//using JwtRegisteredClaimNames = System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames;

//namespace DijkstraImplementation.Services
//{
//    public class JwtService
//    {
//        private readonly string _SECRETKEY = "xtw9ZeRytdpmS57i5U7wjiw5R9MXeUMWfmNmKpOLQb05YF7Iqh5ggvBbgUv4AW5\r\n";
//        public string GenerateToken(string username)
//        {
//            var claim = new[]
//            {

//                new Claim(JwtRegisteredClaimNames.Sub,username),
//                //new Claim(ClaimTypes.Role, username.IsAdmin ? "Admin" : "NonAdmin"),
//                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
//            };

//            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_SECRETKEY));
//            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
//            var token = new JwtSecurityToken(
//                issuer: "https://localhost:7028",
//                audience: "https://localhost:7028",
//                claims: claim,
//                expires: DateTime.Now.AddHours(1),
//                signingCredentials: cred);

//            return new JwtSecurityTokenHandler().WriteToken(token);



//        }
//    }
//}
