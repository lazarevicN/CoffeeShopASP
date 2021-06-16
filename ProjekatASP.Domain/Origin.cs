using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.Domain
{
    public class Origin : Entity
    {
        public string Name { get; set; }
        public virtual ICollection<Coffee> Coffees { get; set; } = new HashSet<Coffee>();
    }
}
