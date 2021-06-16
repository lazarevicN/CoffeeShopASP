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
    public class GetAmountsQuery : IGetAmountsQuery
    {
        private readonly ProjekatASPContext _context;
        private readonly IMapper _mapper;

        public GetAmountsQuery(ProjekatASPContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 9;

        public string Name => "Catching and showing coffees of specific package amount.";

        public PagedResponse<AmountSearchDto> Execute(AmountSearch search)
        {
            var query = _context.Amounts.Where(x => x.DeletedAt == null).Include(x => x.AmountCoffees).ThenInclude(x => x.Coffee).AsQueryable();

            if (search.MinAmount.HasValue)
            {
                query = query.Where(x => x.PackAmount >= search.MinAmount);
            }

            if (search.MaxAmount.HasValue)
            {
                query = query.Where(x => x.PackAmount <= search.MinAmount);
            }

            var amounts = query.Paged<AmountSearchDto, Amount>(search, _mapper);

            if (amounts.Items.Count() == 0)
            {
                throw new EntityNotFoundException(typeof(Amount));
            }

            return amounts;


        }
    }
}
