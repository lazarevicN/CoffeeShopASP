using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.Domain
{
    public class OrderLine : Entity
    {
        public string CoffeeName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int CoffeeAmountId { get; set; }
        public int OrderId { get; set; }
        public virtual CoffeeAmount CoffeeAmount { get; set; } 
        public virtual Order Order { get; set; }
    }
}
