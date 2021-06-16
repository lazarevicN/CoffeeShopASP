using ProjekatASP.Application.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.Application.Searches
{
    public class CoffeeSearch : PagedSearch
    {
        public string Name { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
    }
}
