using NServiceBus;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prototype.Messages
{
    public class CreateEnrollment:ICommand
    {
        public string CompanyId { get; set; }
    }
}
