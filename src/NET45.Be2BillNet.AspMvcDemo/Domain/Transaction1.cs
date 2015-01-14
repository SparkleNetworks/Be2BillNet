
namespace Be2BillNet.AspMvcDemo.Domain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Web;

    [DataContract]
    public class Transaction1
    {
        [DataMember]
        public string OrderId { get; set; }
        [DataMember]
        public string UserId { get; set; }
        [DataMember]
        public string UserEmail { get; set; }
        [DataMember]
        public decimal Amount { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public DateTime DateCreatedUtc { get; set; }

        [DataMember]
        public decimal AmountPaid { get; set; }

        [DataMember]
        public bool IsPaid { get; set; }

        [DataMember]
        public List<string> PaymentIds { get; set; }
    }
}
