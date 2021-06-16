using AutoMapper;
using ProjekatASP.Application.DataTransferObjects;
using ProjekatASP.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.Implementation.Profiles
{
    public class UseCaseLogProfile : Profile
    {
        public UseCaseLogProfile()
        {

            CreateMap<UseCaseLog, UseCaseLogDto>();


        }
    }
}
