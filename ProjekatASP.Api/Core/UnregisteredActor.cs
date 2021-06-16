using ProjekatASP.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjekatASP.Api.Core
{
    public class UnregisteredActor : IApplicationActor
    {
        public int Id => 0;

        public string Email => "Anonymous actor";

        public IEnumerable<int> AllowedUseCases => new List<int> { 1, 5, 9, 13, 21 };
    }
}
