using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjekatASP.Application;
using ProjekatASP.Application.DataTransferObjects;
using ProjekatASP.Implementation.Commands;

namespace ProjekatASP.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly UseCaseExecutor _executor;

        public RegisterController(UseCaseExecutor executor)
        {
            _executor = executor;
        }


        // POST: api/User
        [HttpPost]
        public IActionResult Post([FromBody] UserDto dto, [FromServices] CreateUserCommand command)
        {
            _executor.ExecuteCommand(command, dto);
            return Ok("You have successfully registered!");
        }
    }
}
