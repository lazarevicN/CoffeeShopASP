using AutoMapper;
using ProjekatASP.Application.DataTransferObjects;
using ProjekatASP.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjekatASP.Implementation.Profiles
{
    public class CoffeeProfile : Profile
    {
        public CoffeeProfile()
        {
            CreateMap<Coffee, CoffeeSearchDto>()
                .ForMember(x => x.Amounts, y => y.MapFrom(coffee => coffee.CoffeeAmounts.Select(c =>
                new CoffeeAmountPriceDto
                {
                    Id = c.Id,
                    PackAmount = c.Amount.PackAmount,
                    Price = c.Price
                    
                })));


        }
    }
}
