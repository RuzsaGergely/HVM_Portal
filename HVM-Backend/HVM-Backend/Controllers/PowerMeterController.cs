using Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Application.Helpers;
using Domain;

namespace HVM_Backend.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/powermeter")]
    public class PowerMeterController : ControllerBase
    {
        public HVMContext _context;
        public PrivilegeHelper _privilegeHelper;

        public PowerMeterController(HVMContext context)
        {
            _context = context;
            _privilegeHelper = new PrivilegeHelper(context);
        }

        [HttpGet("whoami")]
        public string WhoAmI()
        {
            
            return User.Claims.FirstOrDefault(x=>x.Type == "UserID").Value;
        }

        [HttpPost("newmeter")]
        public async Task<IActionResult> CreateNewPowermeter(PowerMeter newmeter)
        {
            if(await _privilegeHelper.CheckOperatorPrivilege(User.Claims.FirstOrDefault(x => x.Type == "UserID").Value))
            {
                await _context.PowerMeters.AddAsync(newmeter);
                return Ok();
            } else
            {
                return Unauthorized();
            }
        }
        
    }
}
