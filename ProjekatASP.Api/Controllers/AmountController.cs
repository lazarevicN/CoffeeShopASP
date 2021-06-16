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
    public class AmountController : ControllerBase
    {
        private readonly UseCaseExecutor _executor;

        public AmountController(UseCaseExecutor executor)
        {
            _executor = executor;
        }

        // GET: api/Amount
        [HttpGet]
        public IActionResult Get([FromQuery] AmountSearch search,[FromServices] GetAmountsQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, search));
        }


        // POST: api/Amount
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] AmountDto dto, [FromServices] CreateAmountCommand command)
        {
            _executor.ExecuteCommand(command, dto);
            return Ok("You have successfully added new pack amount!");
        }

        // PUT: api/Amount/5
        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Put(int id, [FromBody] AmountDto dto, [FromServices] UpdateAmountCommand command)
        {
            dto.Id = id;
            _executor.ExecuteCommand(command, dto);
            return Ok("You have successfully updated choosen pack amount.");
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id, [FromServices] DeleteAmountCommand command)
        {
            _executor.ExecuteCommand(command, id);
            return Ok("You have successfully deleted choosen pack amount.");
        }
    }
}
