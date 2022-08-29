using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TokenAuthentication.Models;
using TokenAuthentication.Services;

namespace TokenAuthentication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TokenAuthenticationController : ControllerBase
    {
        private readonly IAuthorTokenService _authorTokenService;
        private readonly IConfiguration _configuration;
        public TokenAuthenticationController(IAuthorTokenService authorTokenService, IConfiguration configuration)
        {
            _authorTokenService = authorTokenService;
            this._configuration = configuration;
        }

        [HttpPost]
        public IActionResult Validate([FromBody]User user)
        {
            string result = string.Empty;
           
            try
            {
                User validate = _authorTokenService.ValidateUser(user.UserName, user.Password);
                if (validate != null)
                {
                    result = BuildToken(_configuration["Jwt:Key"],
                                            _configuration["Jwt:Issuer"],
                                            new[]
                                            {
                                            _configuration["Jwt:Aud1"],
                                            _configuration["Jwt:Aud2"],
                                            _configuration["Jwt:Aud3"]
                                            },
                                            validate.UserName,
                                            validate.UserType,
                                            validate.UserId);
                    var token = new TokenModel
                    {
                        Token = result,
                        IsAuthenticated = true,
                        Message = "Login sucessfull"
                    };
                    return Ok(token);
                }
                else
                {
                    return NotFound(new TokenModel
                    {
                        Token = result,
                        IsAuthenticated = false,
                        Message = "Not a valid user"
                    });
                }
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
            
        }

        private string BuildToken(string key, string issuer, IEnumerable<string> audience, string userName, string userType, long userId)
        {
            var claims = new List<Claim>
            {
                new Claim("userName", !string.IsNullOrWhiteSpace(userName) ? userName : string.Empty),
                new Claim("userType",!string.IsNullOrWhiteSpace(userType) ? userType : string.Empty ),
                new Claim("userId", !string.IsNullOrWhiteSpace(userId.ToString()) ? userId.ToString() : string.Empty),
            };

            claims.AddRange(audience.Select(aud => new Claim(JwtRegisteredClaimNames.Aud, aud)));

            var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new JwtSecurityToken(issuer, issuer, claims, notBefore: DateTime.Now, expires: DateTime.Now.Add(new TimeSpan(20, 30, 0)),
                signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        }

    }
}