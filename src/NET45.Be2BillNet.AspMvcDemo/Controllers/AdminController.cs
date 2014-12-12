
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
            var model = this.Domain.GetAllTransactions();
            return this.View(model);
        }
    }
}