using ProjekatASP.Application.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.Application.Interfaces.Email
{
    public interface IEmailSender
    {
        void Send(SendEmailDto dto);
    }
}
