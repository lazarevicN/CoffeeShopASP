using ProjekatASP.Application.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.Application.Searches
{
    public class AmountSearch : PagedSearch
    {
        public int? MinAmount { get; set; }
        public int? MaxAmount { get; set; }
    }
}
