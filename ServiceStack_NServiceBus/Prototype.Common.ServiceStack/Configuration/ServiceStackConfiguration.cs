using Microsoft.Extensions.Configuration;
using ServiceStack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Prototype.Common.ServiceStack.Configuration
{
    public class ServiceStackConfiguration
    {
        private static JsonFileConfiguration configurationFromJson;

        private ServiceStackConfiguration() { }
        /// <summary>
        /// Gets the request types.
        /// </summary>
        public static IDictionary<Type, string> RequestTypes { get; private set; }

        static ServiceStackConfiguration()
        {
            PopulateRequestTypesDictionary();
        }

        private static void InitializeServiceStackFromJson()
        {
            var configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
                

            var configurationRoot = configurationBuilder.Build();
            configurationFromJson = configurationRoot.GetSection("ServiceStack").Get<JsonFileConfiguration>();
        }

        private static void PopulateRequestTypesDictionary()
        {
            InitializeServiceStackFromJson();

            RequestTypes = new Dictionary<Type, string>();

            try
            {
                if (!configurationFromJson.ClientEndpoints.Any())
                    return;

                foreach (var clientEndpoint in configurationFromJson.ClientEndpoints)
                {
                    var requestTypes = new List<Type>();

                    Assembly referencedAssembly = null;

                    try
                    {
                        referencedAssembly = Assembly.Load(clientEndpoint.ContractsAssembly);
                    }
                    finally
                    {
                        if (referencedAssembly != null)
                        {
                            var contractTypes = referencedAssembly.GetTypes();
                            requestTypes.AddRange(
                                contractTypes.Where(
                                    contractType =>
                                        contractType.CustomAttributes.Any(
                                            a => a.AttributeType == typeof(RouteAttribute))));
                        }
                    }

                    if (requestTypes.Count > 0)
                    {
                        foreach (var requestType in requestTypes)
                        {
                            RequestTypes[requestType] = clientEndpoint.BaseUrl;
                        }
                    }
                }
            }
            catch
            {
                // ignored
            }
        }

    }
}
