using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.Domain
{
    public class Coffee : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int BeanId { get; set; }
        public int OriginId { get; set; }
        public virtual Bean Bean { get; set; }
        public virtual Origin Origin { get; set; }
        public virtual ICollection<CoffeeAmount> CoffeeAmounts { get; set; } = new HashSet<CoffeeAmount>();
        public virtual ICollection<OrderLine> OrderLines { get; set; } = new HashSet<OrderLine>();
    }
}
