using ProjekatASP.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.Application
{
    public interface IUseCaseLogger
    {
        void Log(IUseCase useCase, IApplicationActor actor, object data);
    }
}
