using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.Application
{
    public interface IApplicationActor
    {
        public int Id { get; }
        public string Email { get; }
        public IEnumerable<int> AllowedUseCases { get; }
    }
}
