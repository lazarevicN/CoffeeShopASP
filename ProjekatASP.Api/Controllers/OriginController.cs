using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjekatASP.Application;
using ProjekatASP.Application.DataTransferObjects;
using ProjekatASP.Application.Searches;
using ProjekatASP.Implementation.Commands;
using ProjekatASP.Implementation.Queries;

namespace ProjekatASP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OriginController : ControllerBase
    {

        private readonly UseCaseExecutor _executor;

        public OriginController(UseCaseExecutor executor)
        {
            _executor = executor;
        }



        // GET: api/Origin
        [HttpGet]
        public IActionResult Get([FromQuery] OriginSearch search, [FromServices] GetOriginsQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, search));
        }

        // POST: api/Origin
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] OriginDto dto, [FromServices] CreateOriginCommand command)
        {
            _executor.ExecuteCommand(command, dto);
            return Ok("You have successfully added new origin!");
        }

        // PUT: api/Origin/5
        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Put(int id, [FromBody] OriginDto dto, [FromServices] UpdateOriginCommand command)
        {
            dto.Id = id;
            _executor.ExecuteCommand(command, dto);
            return Ok("You have successfully updated choosen origin!");
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id, [FromServices] DeleteOriginCommand command)
        {
            _executor.ExecuteCommand(command, id);
            return Ok("You have successfully deleted choosen origin!");
        }
    }
}
