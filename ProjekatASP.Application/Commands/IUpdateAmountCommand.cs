using ProjekatASP.Application.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.Application.Commands
{
    public interface IUpdateAmountCommand : ICommand<AmountDto>
    {
    }
}
