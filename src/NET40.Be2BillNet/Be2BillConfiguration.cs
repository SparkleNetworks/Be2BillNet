
namespace Be2BillNet
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Text;
    using Be2BillNet.Internals;
    using Be2BillNet.Resources;

    /// <summary>
    /// The <see cref="Be2BillClient"/> configuration class.
    /// </summary>
    [DataContract(Namespace = Names.DataContractNamespace)]
    public class Be2BillConfiguration
    {
        private string apiIdentifier;
        private string apiKey;
        private string paymentSubmitUrl; // = "https://secure-test.be2bill.com/front/form/process.php";
        private string restUrl; // = "https://secure-test.be2bill.com/front/service/rest/process";

        /// <summary>
        /// Gets or sets the API key.
        /// </summary>
        [DataMember(IsRequired = false, Order = 0)]
        [Display(Name = "Config_ApiKey_Name", Description = "Config_ApiKey_Description", ResourceType = typeof(Strings))]
        public string ApiKey
        {
            get { return this.apiKey; }
            set { this.apiKey = value; }
        }

        /// <summary>
        /// Gets or sets the payment submit URL.
        /// </summary>
        [DataMember(IsRequired = false, Order = 1)]
        [Display(Name = "Config_PaymentSubmitUrl_Name", Description = "Config_PaymentSubmitUrl_Description", ResourceType = typeof(Strings))]
        [RegularExpression("^https://.+", ErrorMessageResourceName = "Config_PaymentSubmitUrl_Regex1", ErrorMessageResourceType = typeof(Strings))]
        public string PaymentSubmitUrl
        {
            get { return this.paymentSubmitUrl; }
            set { this.paymentSubmitUrl = value; }
        }

        /// <summary>
        /// Gets or sets the rest URL.
        /// </summary>
        [DataMember(IsRequired = false, Order = 2)]
        [Display(Name = "Config_RestUrl_Name", Description = "Config_RestUrl_Description", ResourceType = typeof(Strings))]
        [RegularExpression("^https://.+", ErrorMessageResourceName = "Config_RestUrl_Regex1", ErrorMessageResourceType = typeof(Strings))]
        public string RestUrl
        {
            get { return this.restUrl; }
            set { this.restUrl = value; }
        }

        /// <summary>
        /// Gets or sets the API identifier.
        /// </summary>
        [DataMember(IsRequired = false, Order = 3)]
        [Display(Name = "Config_ApiIdentifier_Name", Description = "Config_ApiIdentifier_Description", ResourceType = typeof(Strings))]
        public string ApiIdentifier
        {
            get { return this.apiIdentifier; }
            set { this.apiIdentifier = value; }
        }
    }
}
