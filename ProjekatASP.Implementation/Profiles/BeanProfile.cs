using AutoMapper;
using ProjekatASP.Application.DataTransferObjects;
using ProjekatASP.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjekatASP.Implementation.Profiles
{
    public class BeanProfile : Profile
    {
        public BeanProfile()
        {
            CreateMap<Bean, BeanSearchDto>()
                .ForMember(x => x.Coffees, y => y.MapFrom(coffee => coffee.Coffees.Select(c =>
                new CoffeeSearchDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description
                })));

            CreateMap<BeanSearchDto, Bean>();
        }
    }
}
