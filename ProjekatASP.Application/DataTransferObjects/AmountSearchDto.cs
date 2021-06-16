using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.Application.DataTransferObjects
{
    public class AmountSearchDto
    {
        public int Id { get; set; }
        public int PackAmount { get; set; }
        public decimal Price { get; set; }
        public IEnumerable<CoffeeSearchDto> Coffees { get; set; } = new List<CoffeeSearchDto>();
    }
}
