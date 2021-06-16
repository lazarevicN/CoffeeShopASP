using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.Domain
{
    public class User : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
        public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();
    }
}
