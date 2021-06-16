using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjekatASP.Application;
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
    public class GetOrdersQuery : IGetOrdersQuery
    {
        private readonly ProjekatASPContext _context;
        private readonly IMapper _mapper;
        private readonly IApplicationActor _actor;

        public GetOrdersQuery(ProjekatASPContext context, IMapper mapper, IApplicationActor actor)
        {
            _context = context;
            _mapper = mapper;
            _actor = actor;
        }

        public int Id => 18;

        public string Name => "Catching and showing coffees of specific package amount.";

        public PagedResponse<OrderSearchDto> Execute(OrderSearch search)
        {
            var query = _context.Orders.Include(x => x.OrderLines).AsQueryable();

            if(!string.IsNullOrEmpty(search.Name) || !string.IsNullOrWhiteSpace(search.Name))
            {
                search.Name = search.Name.ToLower();
                query = query.Where(x => x.OrderLines.Any(o => o.CoffeeName.Contains(search.Name)));
            }

            //var user = _context.Users.Find(_actor.Id);

            //if(user.RoleId == 2)
            //{
                //query = query.Where(x => x.UserId == user.Id);
            //}

            var orders = query.Paged<OrderSearchDto, Order>(search, _mapper);

            if(orders.Items.Count() == 0)
            {
                throw new EntityNotFoundException(typeof(Order));
            }

            return orders;
        }
    }
}
