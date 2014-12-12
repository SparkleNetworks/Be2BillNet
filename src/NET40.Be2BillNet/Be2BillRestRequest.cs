
namespace Be2BillNet
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Text;
    using Be2BillNet.Internals;

    /// <summary>
    /// A Be2Bill API request.
    /// </summary>
    [DataContract(Namespace = Names.DataContractNamespace)]
    public class Be2BillRestRequest
    {
        /// <summary>
        /// Gets or sets the method.
        /// </summary>
        [DataMember(Name = "method")]
        public string Method { get; set; }

        /// <summary>
        /// Gets or sets the parameters.
        /// </summary>
        [DataMember(Name = "params")]
        public IDictionary<string, string> Params { get; set; }
    }
}
