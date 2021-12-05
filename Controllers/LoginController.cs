using DemoApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _config;
        //adding users
        private List<User> appUsers = new List<User>
        {
            new User{ FirstName ="Omair",UserName ="admin",Password="1234",UserType="Admin"},
            new User{FirstName ="Ali",UserName ="ali",Password ="1234",UserType ="User"}
        };
        public LoginController(IConfiguration  config)
        {
            _config = config; 
        }
        
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login([FromBody] User login)
        {
            IActionResult response = Unauthorized();
            User user = AuthenticateUser(login);
            if (user != null)
            {
                //invoke jwt after successfull authentication
                var tokenString = GenerateJwt(user);
                response = Ok(new
                {
                    token= tokenString,
                    userDetails = user
                });
            }
            return response;
        }

        private string GenerateJwt(User userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:SecretKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            // claims to be sent as payload with our JWT
             var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,userInfo.UserName),
            new Claim("firstName", userInfo.FirstName.ToString()),
            new Claim("role",userInfo.UserType),
            new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };
            var token = new JwtSecurityToken(issuer: _config["Jwt:Issuer"],
                        audience:_config["Jwt:Audience"],
                        claims:claims,
                        expires:DateTime.Now.AddMinutes(30),
                        signingCredentials:credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private User AuthenticateUser(User loginCredentials)
        {
            //verify user
            User user = appUsers.SingleOrDefault(m => m.UserName == loginCredentials.UserName && m.Password == loginCredentials.Password);
            return user;
        }
    }
}
