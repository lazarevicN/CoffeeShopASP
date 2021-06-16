using System;
using System.Collections.Generic;

namespace ProjekatASP.Domain
{
    public class Bean : Entity
    {
        public string Name { get; set; }
        public virtual ICollection<Coffee> Coffees { get; set; } = new HashSet<Coffee>();
    }
}
