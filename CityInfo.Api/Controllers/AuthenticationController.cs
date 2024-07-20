using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace CityInfo.Api.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IConfiguration configuration;

        public class AuthenticationBody
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }
        public class UserInfo
        {
            public string Username { get; set; }
            public string Password { get; set; }
            public string Firstname { get; set; }
            public string Lastname { get; set; } = string.Empty;

            public bool Enabled { get; set; }
            public string Email { get; set; }
            public string PasswordHash { get; set; } = string.Empty;
            public object UserId { get; internal set; }
            public string City { get; internal set; }

            public
                UserInfo()
            { }

        }

        public AuthenticationController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        [HttpPost("login")]
        public ActionResult<string> Login(AuthenticationBody authenticationBody)
        {
            UserInfo user = ValidateCredential(authenticationBody);
            if (user == null)
            {
                return Unauthorized();
            }


            //--1 we need a security key SymmetricSecurityKey defined in Microsft.IdentityModel.Token
            SymmetricSecurityKey
                symmetricSecurityKey = new(
                            Convert.FromBase64String(configuration["Authentication:SecretForKey"]));
            SymmetricSecurityKey securityKey = symmetricSecurityKey;

            // we need to sign tye token

            SigningCredentials signingCredentials = new(securityKey, SecurityAlgorithms.HmacSha256);

            // a token  can con what the user can be  user key value pair Claims

            List<Claim> claims = new()
            {
                new("sub", user.UserId.ToString()),
                new("given_name", user.Firstname),
                new("family_name", user.Lastname),
                new("city", user.City),
                new("sub", user.City)
            };


            JwtSecurityToken token = new(
                configuration["Authentication:Issuer"],
                configuration["Authentication:Audience"],
                claims,
                DateTime.UtcNow,
                DateTime.UtcNow.AddDays(1),
                signingCredentials
                );

            string tokentoReturn = new JwtSecurityTokenHandler().WriteToken(token);

            return tokentoReturn;

        }

        private UserInfo ValidateCredential(AuthenticationBody
            authenticationBody)
        {
            return new UserInfo
            {
                Firstname =
                "hakim",
                Lastname = "maakeb",
                City = "Oran",


            };


        }
    }
}
