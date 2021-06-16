using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.Domain
{
    public class Role : Entity
    {
        public string Name { get; set; }
        public virtual ICollection<User> Users { get; set; } = new HashSet<User>();
    }
}
