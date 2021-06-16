using ProjekatASP.Application.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.Application.Searches
{
    public class UseCaseLogSearch : PagedSearch
    {
        public string UseCaseName { get; set; }
    }
}
