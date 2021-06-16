using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.Application.DataTransferObjects
{
    public class OriginSearchDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<CoffeeSearchDto> Coffees { get; set; } = new List<CoffeeSearchDto>();
    }
}
