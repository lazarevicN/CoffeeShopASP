using ProjekatASP.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.Application
{
    public interface ICommand<TRequest> : IUseCase
    {
        void Execute(TRequest request);
    }

    public interface IQuery<TSearch, TResult> : IUseCase
    {
        TResult Execute(TSearch search);
    }
}
