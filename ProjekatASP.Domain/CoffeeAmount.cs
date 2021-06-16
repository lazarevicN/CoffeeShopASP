using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.Domain
{
    public class CoffeeAmount : Entity
    {
        public int CoffeeId { get; set; }
        public int AmountId { get; set; }
        public decimal Price { get; set; }
        public virtual Coffee Coffee { get; set; }
        public virtual Amount Amount { get; set; }
        public virtual ICollection<OrderLine> OrderLines { get; set; } = new HashSet<OrderLine>();
    }
}
