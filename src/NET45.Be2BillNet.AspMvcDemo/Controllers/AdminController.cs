
namespace Be2BillNet.AspMvcDemo.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    public class AdminController : Controller
    {
        public ActionResult Index()
        {
            var model = this.Domain.GetAllTransactions()
                .OrderByDescending(t => t.DateCreatedUtc)
                .ToList();
            return this.View(model);
        }

        public ActionResult BebillItems()
        {
            var model = this.Domain.GetAllBebillTransactions();
            return this.View(model);
        }

        public ActionResult Transaction1(string id)
        {
            var item = this.Domain.GetTransaction1(id);
            return this.View(item);
        }

        public ActionResult BebillItem(string id)
        {
            var item = this.Domain.GetBebillItem(id);
            return this.View(item);
        }
    }
}
