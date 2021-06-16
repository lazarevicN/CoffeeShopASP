using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.Application.DataTransferObjects
{
    public class CoffeeSearchDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<CoffeeAmountPriceDto> Amounts { get; set; } = new List<CoffeeAmountPriceDto>();
    }

}
