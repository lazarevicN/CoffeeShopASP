using AutoMapper;
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
    public class GetUseCaseLogsQuery : IGetUseCaseLogsQuery
    {
        private readonly ProjekatASPContext _context;
        private readonly IMapper _mapper;

        public GetUseCaseLogsQuery(ProjekatASPContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 20;

        public string Name => "Fetching and showing use case logs.";

        public PagedResponse<UseCaseLogDto> Execute(UseCaseLogSearch search)
        {
            var query = _context.UseCaseLogs.AsQueryable();

            if (!string.IsNullOrEmpty(search.UseCaseName) && !string.IsNullOrWhiteSpace(search.UseCaseName))
            {

                search.UseCaseName = search.UseCaseName.ToLower();

                query = query.Where(x => x.UseCaseName.ToLower().Contains(search.UseCaseName));
            }

            var useCaseLogs = query.Paged<UseCaseLogDto, UseCaseLog>(search, _mapper);

            if(useCaseLogs.Items.Count() == 0)
            {
                throw new EntityNotFoundException(typeof(UseCaseLog));
            }

            return useCaseLogs;
        }
    }
}
