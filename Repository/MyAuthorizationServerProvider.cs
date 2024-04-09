
using Microsoft.IdentityModel.Tokens;
using MyLearningRoomBackend.Dto;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using System.Text;

namespace MyLearningRoomBackend.Repository
{
    public class MyAuthorizationServerProvider
    {
        private readonly IConfiguration _config;
        public MyAuthorizationServerProvider(IConfiguration config)
        {
            _config = config;
        }
        public string GenerateToken(UserDto user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:key"]));
            var credentials = new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"], _config["Jwt:Audience"], null,expires:DateTime.Now.AddMinutes(1),signingCredentials:credentials);
             
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
