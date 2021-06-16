using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.Domain
{
    public class Order : Entity
    {
        public string Address { get; set; }
        public DateTime DateOfOrder { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<OrderLine> OrderLines { get; set; } = new HashSet<OrderLine>();
    }
}
