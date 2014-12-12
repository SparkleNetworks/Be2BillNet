
namespace Be2BillNet.AspMvcDemo.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;
    using System.Web;
    using Be2BillNet.AspMvcDemo.Domain;

    public class Controller : System.Web.Mvc.Controller
    {
        public Controller()
            : base()
        {
            this.BebillConfiguration = new Be2BillConfiguration
            {
                ApiIdentifier = ConfigurationManager.AppSettings["Be2Bill.ApiIdentifier"] ?? string.Empty,
                ApiKey = ConfigurationManager.AppSettings["Be2Bill.ApiKey"] ?? string.Empty,
                PaymentSubmitUrl = ConfigurationManager.AppSettings["Be2Bill.PaymentSubmitUrl"] ?? string.Empty,
                RestUrl = ConfigurationManager.AppSettings["Be2Bill.RestUrl"] ?? string.Empty,
            };
            this.BebillClient = new Be2BillClient(this.BebillConfiguration);
        }

        public Be2BillConfiguration BebillConfiguration { get; set; }

        public Be2BillClient BebillClient { get; set; }

        public DataService Domain
        {
            get { return this.HttpContext.GetDomain(); }
        }
    }
}