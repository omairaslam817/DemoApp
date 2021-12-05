using DemoApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoApp.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        [Route("GetUserData")]
        [Authorize(Policy = Common.Common.User)]
        public IActionResult GetUserData()
        {
            return Ok("This is an normal user");
        }

        [HttpGet]
        [Route("GetAdminData")]
        [Authorize(Policy = Common.Common.Admin)]
        public IActionResult GetAdminData()
        {
            return Ok("This is an Admin user");
        }
    }
}
