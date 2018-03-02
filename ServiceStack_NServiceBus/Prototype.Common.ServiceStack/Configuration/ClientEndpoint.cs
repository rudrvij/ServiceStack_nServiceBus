using System;
using System.Collections.Generic;
using System.Text;

namespace Prototype.Common.ServiceStack.Configuration
{
    public class ClientEndpoint
    {
        /// <summary>
        /// Gets or sets the base URL.
        /// </summary>
        public string BaseUrl { get; set; }

        /// <summary>
        /// Gets or sets the contracts assembly.
        /// </summary>
        public string ContractsAssembly { get; set; }
    }
}
