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
    public class GetCoffeesQuery : IGetCoffeesQuery
    {

        private readonly ProjekatASPContext _context;
        private readonly IMapper _mapper;

        public GetCoffeesQuery(ProjekatASPContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 13;

        public string Name => "Catching and showing coffees.";

        public PagedResponse<CoffeeSearchDto> Execute(CoffeeSearch search)
        {
            var query = _context.Coffees.Include(x => x.CoffeeAmounts).ThenInclude(x => x.Amount).Where(x => x.DeletedAt == null).AsQueryable();

            if(!string.IsNullOrEmpty(search.Name) || !string.IsNullOrWhiteSpace(search.Name))
            {
                search.Name = search.Name.ToLower();

                query = query.Where(x => x.Name.ToLower().Contains(search.Name));
            }

            var coffees = query.Paged<CoffeeSearchDto, Coffee>(search, _mapper);

            if (coffees.Items.Count() == 0)
            {
                throw new EntityNotFoundException(typeof(Coffee));
            }

            return coffees;


        }
    }
}
