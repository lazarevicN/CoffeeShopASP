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
    public class OrderController : ControllerBase
    {
        private readonly UseCaseExecutor _executor;

        public OrderController(UseCaseExecutor executor)
        {
            _executor = executor;
        }

        // GET: api/Order
        [HttpGet]
        [Authorize]
        public IActionResult Get([FromQuery] OrderSearch search, [FromServices] GetOrdersQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, search));
        }

        // POST: api/Order
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] OrderDto dto, [FromServices] CreateOrderCommand command)
        {
            _executor.ExecuteCommand(command, dto);
            return Ok("Thank You for Your purchase!");
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id, [FromServices] DeleteOrderCommand command)
        {
            _executor.ExecuteCommand(command, id);
            return Ok("You have successfully deleted choosen order!");
        }
    }
}
