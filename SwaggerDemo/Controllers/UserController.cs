using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SwaggerDemo.Interface;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SwaggerDemo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUser _user;

        public UserController(IUser user)
        {
            _user = user;
        }


        //[AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult> Authenticate(string userName , string PassWord)
        {
            var user = await _user.Authenticate(userName, PassWord);
            if(user==null)
            {
                return BadRequest(new { message = "UserName and Password are incorrect" });
            }
            return Ok(user);
        }
    }
}
