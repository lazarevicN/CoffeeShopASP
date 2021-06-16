using AutoMapper;
using ProjekatASP.Application.DataTransferObjects;
using ProjekatASP.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjekatASP.Implementation.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderSearchDto>()
                .ForMember(x => x.OrderLineSearchDtos, y => y.MapFrom(o => o.OrderLines.Select(ol =>
                new OrderLineSearchDto
                {
                    CoffeeName = ol.CoffeeName,
                    Price = ol.Price,
                    Quantity = ol.Quantity
                    
                })));
        }
    }
}
