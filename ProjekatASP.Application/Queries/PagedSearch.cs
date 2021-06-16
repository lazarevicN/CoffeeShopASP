using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.Application.Queries
{
    public abstract class PagedSearch
    {
        public int PerPage { get; set; } = 4;
        public int Page { get; set; } = 1;
    }
}
