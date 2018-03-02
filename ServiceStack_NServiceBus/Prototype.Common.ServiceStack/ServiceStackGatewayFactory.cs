using ServiceStack;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prototype.Common.ServiceStack
{
    public class ServiceStackGatewayFactory : ServiceGatewayFactoryBase
    {
        private readonly IDictionary<Type, string> requestTypes;

        public ServiceStackGatewayFactory(IDictionary<Type, string> requestTypes)
        {
            this.requestTypes = requestTypes;
        }
        public override IServiceGateway GetGateway(Type requestType)
        {
            var isLocal = HostContext.Metadata.RequestTypes.Contains(requestType);
            IServiceGateway gateway = null;
            if(isLocal)
            {
                gateway = (IServiceGateway)base.localGateway;
            }
            else
            {
                if(requestTypes.ContainsKey(requestType))
                {
                    string baseUrl = requestTypes[requestType];
                    return new JsonServiceClient(baseUrl);
                }
            }            
            return gateway;
        }
    }
}
