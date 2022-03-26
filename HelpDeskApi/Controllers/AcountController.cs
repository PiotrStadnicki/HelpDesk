using HelpDeskApi.Models;
using HelpDeskApi.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpDeskApi.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AcountController: ControllerBase
    {
        private readonly IAcountService _accountService;

        public AcountController(IAcountService accountService)
        {
            _accountService = accountService;
            
        }

       
        [HttpPost("register")]
        public ActionResult RegisterUser([FromBody] RegisterUserDto dto)
        {
            _accountService.RegisterUser(dto);
            return Ok();
        }

        [HttpPost("login")]
        public ActionResult Login([FromBody] LoginDto dto)
        {
            string token = _accountService.GenerateJWT(dto);
            return Ok(token);

        }

    }
}
