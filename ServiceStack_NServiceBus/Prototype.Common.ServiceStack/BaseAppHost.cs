using ServiceStack;
using System;
using System.Collections.Generic;
using System.Text;
using Funq;
using Prototype.Common.ServiceStack.Configuration;
using ServiceStack.Web;
using System.Reflection;

namespace Prototype.Common.ServiceStack
{
    public class BaseAppHost : AppHostBase
    {
        protected BaseAppHost(string serviceName, params Assembly[] assembliesWithServices) : base(serviceName, assembliesWithServices)
        { }

        public override void Configure(Container container)
        {
            Plugins.Add(new PostmanFeature());
            
        }
    }
}
