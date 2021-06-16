using ProjekatASP.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjekatASP.Api.Core
{
    public class JwtUser : IApplicationActor
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public IEnumerable<int> AllowedUseCases { get; set; }
    }
}
