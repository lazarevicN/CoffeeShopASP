using AutoMapper;
using ProjekatASP.Application.DataTransferObjects;
using ProjekatASP.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjekatASP.Implementation.Profiles
{
    public class AmountProfile : Profile
    {
        public AmountProfile()
        {
            CreateMap<Amount, AmountSearchDto>()
                .ForMember(x => x.Coffees, y => y.MapFrom(coffee => coffee.AmountCoffees.Select(c =>
                new CoffeeSearchDto
                {
                    Id = c.Coffee.Id,
                    Name = c.Coffee.Name,
                    Description = c.Coffee.Description
                })));

            CreateMap<AmountDto, Amount>();
        }
    }
}
