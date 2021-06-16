using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.Application.DataTransferObjects
{
    public class OrderDto
    {
        public string Address { get; set; }
        public IEnumerable<OrderLineDto> OrderLines { get; set; } = new List<OrderLineDto>();
    }

    public class OrderLineDto
    {
        public int CoffeeId { get; set; }
        public int AmountId { get; set; }
        public int Quantity { get; set; }
    }
}
