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
    public class BeanController : ControllerBase
    {
        private readonly UseCaseExecutor _executor;

        public BeanController(UseCaseExecutor executor)
        {
            _executor = executor;
        }

        // GET: api/Bean
        [HttpGet]
        public IActionResult Get([FromQuery] BeanSearch search, [FromServices] GetBeansQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, search));
        }


        // POST: api/Bean
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] BeanDto dto, [FromServices] CreateBeanCommand command)
        {
            _executor.ExecuteCommand(command, dto);
            return Ok("You have successfully added new type of coffee bean!");
        }

        // PUT: api/Bean/5
        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Put(int id, [FromBody] BeanDto dto, [FromServices] UpdateBeanCommand command)
        {
            dto.Id = id;
            _executor.ExecuteCommand(command, dto);
            return Ok("You have successfully updated choosen coffee bean.");
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id, [FromServices] DeleteBeanCommand command)
        {
            _executor.ExecuteCommand(command, id);
            return Ok("You have successfully deleted choosen coffee bean.");
        }
    }
}
