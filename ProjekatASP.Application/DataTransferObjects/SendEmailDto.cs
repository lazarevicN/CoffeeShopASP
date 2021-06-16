using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.Application.DataTransferObjects
{
    public class SendEmailDto
    {
        public string SendTo { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
    }
}
