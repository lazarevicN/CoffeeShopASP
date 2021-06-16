using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.Application.DataTransferObjects
{
    public class CoffeeAmountPriceDto
    {
        public int Id { get; set; }
        public int PackAmount { get; set; }
        public decimal Price { get; set; }
    }
}
