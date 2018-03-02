using NServiceBus;
using ServiceStack;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prototype.Common.ServiceStack
{
    public class BaseService: Service
    {
        public IMessageSession ServiceBusEndpoint { get; set; }
    }
}
