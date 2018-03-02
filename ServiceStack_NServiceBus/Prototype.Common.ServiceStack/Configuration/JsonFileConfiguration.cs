using System;
using System.Collections.Generic;
using System.Text;

namespace Prototype.Common.ServiceStack.Configuration
{
    internal class JsonFileConfiguration
    {        
        /// <summary>
        /// Gets or sets the settings.
        /// </summary>
        public IDictionary<string, string> Settings { get; set; }

        /// <summary>
        /// Gets or sets the client endpoints.
        /// </summary>
        public IList<ClientEndpoint> ClientEndpoints { get; set; }

     
    }
}
