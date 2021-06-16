using ProjekatASP.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.Application.Exceptions
{
    public class UnauthorizedUseCaseException : Exception
    {
        public UnauthorizedUseCaseException(IUseCase useCase, IApplicationActor actor)
            :base($"Actor with an email:{actor.Email}, with an id - '{actor.Id}', tried to execute: {useCase.Name}.") 
        {

        }
    }
}
