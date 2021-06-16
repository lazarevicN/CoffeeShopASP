using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.Domain
{
    public class Amount : Entity
    {
        public int PackAmount { get; set; }
        public virtual ICollection<CoffeeAmount> AmountCoffees { get; set; } = new HashSet<CoffeeAmount>();
    }
}
