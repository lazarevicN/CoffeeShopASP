using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.Application.DataTransferObjects
{
    public class OrderSearchDto
    {
        public string Address { get; set; }
        public DateTime DateOfOrder { get; set; }
        public IEnumerable<OrderLineSearchDto> OrderLineSearchDtos { get; set; } = new HashSet<OrderLineSearchDto>();
    }

    public class OrderLineSearchDto
    {
        public string CoffeeName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
