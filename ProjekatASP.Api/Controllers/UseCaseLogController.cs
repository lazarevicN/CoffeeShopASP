using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjekatASP.Application;
using ProjekatASP.Application.Searches;
using ProjekatASP.Implementation.Queries;

namespace ProjekatASP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UseCaseLogController : ControllerBase
    {
        private readonly UseCaseExecutor _executor;

        public UseCaseLogController(UseCaseExecutor executor)
        {
            _executor = executor;
        }

        // GET: api/UseCaseLog
        [HttpGet]
        [Authorize]
        public IActionResult Get([FromQuery] UseCaseLogSearch search, [FromServices] GetUseCaseLogsQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, search));
        }
    }
}
