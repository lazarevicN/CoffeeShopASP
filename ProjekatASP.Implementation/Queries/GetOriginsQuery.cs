using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjekatASP.Application.DataTransferObjects;
using ProjekatASP.Application.Exceptions;
using ProjekatASP.Application.Queries;
using ProjekatASP.Application.Searches;
using ProjekatASP.Domain;
using ProjekatASP.EfDataAccess;
using ProjekatASP.Implementation.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjekatASP.Implementation.Queries
{
    public class GetOriginsQuery : IGetOriginsQuery
    {
        private readonly ProjekatASPContext _context;
        private readonly IMapper _mapper;

        public GetOriginsQuery(ProjekatASPContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 5;

        public string Name => "Catching and showing coffees origins.";

        public PagedResponse<OriginSearchDto> Execute(OriginSearch search)
        {
            var query = _context.Origins.Where(x => x.DeletedAt == null).Include(x => x.Coffees).AsQueryable();

            if (!string.IsNullOrEmpty(search.Name) || !string.IsNullOrWhiteSpace(search.Name))
            {
                search.Name = search.Name.ToLower();

                query = query.Where(x => x.Name.ToLower().Contains(search.Name));
            }

            var origins = query.Paged<OriginSearchDto, Origin>(search, _mapper);

            if (origins.Items.Count() == 0)
            {
                throw new EntityNotFoundException(typeof(Origin));
            }

            return origins;
        }
    }
}
