
namespace Be2BillNet.AspMvcDemo.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    public class PayController : Controller
    {
        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult PayForm(bool partial = false)
        {
            // data you should gather
            var transaction = this.Domain.CreateRandomTransaction();

            // create a unique order id & keep track if it
            var orderId = transaction.OrderId + "|" + DateTime.UtcNow.ToString("mmss").Substring(0, 3);
            this.Domain.CreateEmptyBebillitem(orderId);

            // now build a form collection
            var data = this.BebillClient.CreateAuthorizationParameters(
                orderId,
                transaction.UserId,
                transaction.UserEmail,
                transaction.Description,
                transaction.Amount,
                createAlias: true);
            this.BebillClient.SetPayWithForm(data, false, false);
            this.BebillClient.SetHash(data);

            this.ViewBag.Configuration = this.BebillConfiguration;
            this.ViewBag.Data = data;

            if (partial)
                return this.PartialView(transaction);
            else
                return this.View(transaction);
        }
    }
}
