using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjekatASP.Api.Core;
using ProjekatASP.Application.DataTransferObjects;

namespace ProjekatASP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly JwtManager _manager;

        public LoginController(JwtManager manager)
        {
            _manager = manager;
        }

        // POST: api/Login
        [HttpPost]
        public IActionResult Post([FromBody] LoginDto dto)
        {
            var token = _manager.MakeToken(dto.Email, dto.Password);

            if(token == null)
            {
                return Unauthorized();
            }
            return Ok(new { token });
        }

    }
}
