﻿using ProjekatASP.Application.DataTransferObjects;
using ProjekatASP.Application.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.Application.Queries
{
    public interface IGetUseCaseLogsQuery : IQuery<UseCaseLogSearch, PagedResponse<UseCaseLogDto>>
    {
    }
}
