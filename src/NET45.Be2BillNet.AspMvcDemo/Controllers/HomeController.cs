
namespace Be2BillNet.AspMvcDemo.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using System.Web.Mvc;
    using Be2BillNet.AspMvcDemo.Domain;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            this.ViewBag.Configuration = this.BebillConfiguration;
            this.ViewBag.IsConfigured = !string.IsNullOrEmpty(this.BebillConfiguration.ApiIdentifier)
                && !string.IsNullOrEmpty(this.BebillConfiguration.ApiKey)
                && !string.IsNullOrEmpty(this.BebillConfiguration.PaymentSubmitUrl)
                && !string.IsNullOrEmpty(this.BebillConfiguration.RestUrl);

            return this.View();
        }

        public ActionResult PayForm(bool partial = false)
        {
            // data you should gather
            var transaction = this.Domain.CreateRandomTransaction();

            // now build a form collection
            var data = this.BebillClient.CreateAuthorizationParameters(
                transaction.OrderId,
                transaction.UserId,
                transaction.UserEmail,
                transaction.Description,
                transaction.Amount,
                createAlias: true);
            this.BebillClient.SetPayWithForm(data, false, false);

            this.ViewBag.Configuration = this.BebillConfiguration;
            this.ViewBag.Data = data;

            if (partial)
                return this.PartialView(transaction);
            else
                return this.View(transaction);
        }
    }
}
