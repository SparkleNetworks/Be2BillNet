
namespace Be2BillNet.AspMvcDemo.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using Be2BillNet.AspMvcDemo.Stuff;

    /// <summary>
    /// Helps log inbound HTTP requests for debugging.
    /// YOU SHOULD NOT USE THAT IN PRODUCTION.
    /// This controller exposes inbound HTTP requests containing payment informations.
    /// DO NOT USE THAT IN PRODUCTION.
    /// </summary>
    public class HttpLogController : Controller
    {
        public ActionResult Index(bool? ChangeStatus)
        {
            if (ChangeStatus != null)
            {
                LogRequestAttribute.SetIsEnabled(this.HttpContext, ChangeStatus.Value);
                return this.RedirectToAction("Index");
            }

            this.ViewBag.IsEnabled = LogRequestAttribute.IsEnabled(this.HttpContext);

            return this.View(LogRequestAttribute.GetItems(this.HttpContext));
        }

        public ActionResult ClearTemporaryData()
        {
            LogRequestAttribute.ClearItems(this.HttpContext);
            return this.RedirectToAction("Index");
        }

        [LogRequest]
        public ActionResult Test()
        {
            return this.RedirectToAction("Index");
        }
    }
}
