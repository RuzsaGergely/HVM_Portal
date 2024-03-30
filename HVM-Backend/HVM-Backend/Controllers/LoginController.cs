using Application.DTOs;
using BCrypt.Net;
using Domain;
using Infrastructure;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace HVM_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private IConfiguration _config;
        private HVMContext _dbContext;
        public LoginController(IConfiguration config, HVMContext dbContext)
        {
            _config = config;
            _dbContext = dbContext;
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
                return Unauthorized();
            }

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var Sectoken = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              null,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            var token = new JwtSecurityTokenHandler().WriteToken(Sectoken);

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

            await _dbContext.Users.AddAsync(new_user_entity);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
