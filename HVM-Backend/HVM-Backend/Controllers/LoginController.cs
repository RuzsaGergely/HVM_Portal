using Application.DTOs;
using Application.Helpers;
using BCrypt.Net;
using Domain;
using Infrastructure;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HVM_Backend.Controllers
{
    [ApiController]
    [Route("api/login")]
    public class LoginController : ControllerBase
    {
        private IConfiguration _config;
        private HVMContext _dbContext;
        private LoggerHelper _loggerHelper;
        public LoginController(IConfiguration config, HVMContext dbContext)
        {
            _config = config;
            _dbContext = dbContext;
            _loggerHelper = new LoggerHelper(_dbContext);
        }

        [HttpPost("authorization")]
        public async Task<IActionResult> Authorize([FromBody] LoginInputDto loginRequest)
        {
            var user_entity = await _dbContext.Users.Where(x => x.EmailAddress == loginRequest.Username || x.Username == loginRequest.Username).FirstOrDefaultAsync();

            if(user_entity == null)
            {
                return Unauthorized();
            }

            bool verified = BCrypt.Net.BCrypt.Verify(loginRequest.Password, user_entity.PasswordHash);

            if(!verified)
            {
                await _loggerHelper.CreateLog("INFO", "Unsuccessful login attempt.", user_entity.Username);
                return Unauthorized();
            }

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user_entity.Username),
                new Claim(JwtRegisteredClaimNames.Email, user_entity.EmailAddress),
                new Claim("UserID", user_entity.Id.ToString())
            };

            var Sectoken = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              claims,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            var token = new JwtSecurityTokenHandler().WriteToken(Sectoken);

            await _loggerHelper.CreateLog("INFO", "User logged in.", user_entity.Username, user_entity);
            return Ok(token);
        }

        [HttpPost("registration")]
        public async Task<IActionResult> Register([FromBody] RegisterInputDto registerRequest)
        {
            var check_entity = await _dbContext.Users.Where(x => x.EmailAddress == registerRequest.Username || x.Username == registerRequest.Username).AnyAsync();

            if(check_entity)
            {
                return BadRequest();
            }

            var new_user_entity = new User()
            {
                Username = registerRequest.Username,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(registerRequest.Password),

                LastName = registerRequest.LastName,
                FirstName = registerRequest.FirstName,
                
                EmailAddress = registerRequest.EmailAddress,
                PhoneNumber = registerRequest.PhoneNumber,

                CompanyName = registerRequest.CompanyName,
                IsLegalEntity = registerRequest.IsLegalEntity,
                VATnumber = registerRequest.VATnumber,

                PowerMeters = new List<PowerMeter>(),
                LastLogin = DateTime.Now,

                IsDeleted = false,
                IsOperator = false    
            };

            await _loggerHelper.CreateLog("INFO", "New user created.", new_user_entity.Username);

            return Ok();
        }
    }
}
