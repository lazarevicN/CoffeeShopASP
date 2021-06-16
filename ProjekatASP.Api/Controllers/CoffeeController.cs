using System;
using System.Collections.Generic;
using System.IO;
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
    public class CoffeeController : ControllerBase
    {
        private readonly UseCaseExecutor _executor;

        public CoffeeController(UseCaseExecutor executor)
        {
            _executor = executor;
        }

        // GET: api/Coffee
        [HttpGet]
        public IActionResult Get([FromQuery] CoffeeSearch search, [FromServices] GetCoffeesQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, search));
        }

        // POST: api/Coffee
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromForm] CoffeeDto dto, [FromServices] CreateCoffeeCommand command)
        {
            var guid = Guid.NewGuid();
            var extension = Path.GetExtension(dto.Image.FileName);
            var newImageName = guid + extension;
            var path = Path.Combine("wwwroot", "images", newImageName);


            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                dto.Image.CopyTo(fileStream);
            }


            _executor.ExecuteCommand(command, dto);
            return Ok("You have successfully added new coffee!");
        }

        // PUT: api/Coffee/5
        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Put(int id, [FromBody] CoffeeDto dto, [FromServices] UpdateCoffeeCommand command)
        {
            dto.Id = id;
            _executor.ExecuteCommand(command, dto);
            return Ok("You have successfully updated choosen coffee!");
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id, [FromServices] DeleteCoffeeCommand command)
        {
            _executor.ExecuteCommand(command, id);
            return Ok("You have successfully deleted choosen coffee!");
        }
    }
}
