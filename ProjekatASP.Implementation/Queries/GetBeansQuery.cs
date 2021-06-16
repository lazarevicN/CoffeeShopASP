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
    public class GetBeansQuery : IGetBeansQuery
    {
        private readonly ProjekatASPContext _context;
        private readonly IMapper _mapper;   

        public GetBeansQuery(ProjekatASPContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 1;

        public string Name => "Catching and showing coffees of specific bean type.";

        public PagedResponse<BeanSearchDto> Execute(BeanSearch search)
        {
            var query = _context.Beans.Where(x => x.DeletedAt == null).Include(x => x.Coffees).AsQueryable();

            if(!string.IsNullOrEmpty(search.Name) || !string.IsNullOrWhiteSpace(search.Name))
            {
                search.Name = search.Name.ToLower();

                query = query.Where(x => x.Name.ToLower().Contains(search.Name));
            }

            var beans = query.Paged<BeanSearchDto, Bean>(search, _mapper);

            if(beans.Items.Count() == 0)
            {
                throw new EntityNotFoundException(typeof(Bean));
            }

            return beans;
        }
    }
}
