
namespace Be2BillNet.AspMvcDemo.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Web.Mvc;
    using Be2BillNet.AspMvcDemo.Stuff;

    [LogRequest]
    public class Be2BillController : Controller
    {
        /// <summary>
        /// FR: URL de notification de transactions 
        /// EN: Transaction feedback URL 
        /// WARNING: YOU SHOULD NOT USE THIS NAME FOR THIS ACTION IN PRODUCTION.
        /// </summary>
        /// <returns></returns>
        public ActionResult TransactionHook()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// FR: URL de notification d’impayés 
        /// EN: Chargeback feedback URL 
        /// WARNING: YOU SHOULD NOT USE THIS NAME FOR THIS ACTION IN PRODUCTION.
        /// </summary>
        /// <returns></returns>
        public ActionResult OverdueHook()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// FR: URL du modèle de formulaire de paiement 
        /// EN: Payment form template 
        /// WARNING: YOU SHOULD NOT USE THIS NAME FOR THIS ACTION IN PRODUCTION.
        /// </summary>
        /// <returns></returns>
        public ActionResult FormModel()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// FR: URL du modèle de formulaire version mobile 
        /// EN: Mobile form template 
        /// WARNING: YOU SHOULD NOT USE THIS NAME FOR THIS ACTION IN PRODUCTION.
        /// </summary>
        /// <returns></returns>
        public ActionResult MobileFormModel()
        {
            throw new NotImplementedException();
        }
        
        /// <summary>
        /// FR: URL de redirection après un traitement formulaire ou 3DSECURE 
        /// EN: Redirection URL after payment form or 3DSECURE processing 
        /// WARNING: YOU SHOULD NOT USE THIS NAME FOR THIS ACTION IN PRODUCTION.
        /// </summary>
        /// <returns></returns>
        public ActionResult FormReturn()
        {
            var data = TransactionResult.Create(this.Request.QueryString);

            bool isHashValid = this.BebillClient.VerifyParameters(data.ToDictionary(), this.BebillConfiguration.ApiKey, data.Hash);
            this.ViewBag.IsHashValid = isHashValid;

            if (data.ExecCode == "0000" && isHashValid)
            {
                var splittedId = data.OrderId.Split(new char[] { '|', }, 2);

                var result = this.Domain.AddPaymentToTransaction1(splittedId[0], data);
                this.ViewBag.Result = result;
            }

            this.ViewBag.ExecCode = Be2BillUtility.GetNameForExecCode(data.ExecCode, CultureInfo.CurrentUICulture);

            this.Domain.SaveBebillTransaction(data);

            return this.View(data);
        }

        /// <summary>
        /// FR: URL de redirection lors de l’annulation d’un traitement formulaire 
        /// EN: Redirection URL after payment form cancelling 
        /// WARNING: YOU SHOULD NOT USE THIS NAME FOR THIS ACTION IN PRODUCTION.
        /// </summary>
        /// <returns></returns>
        public ActionResult FormCancel()
        {
            throw new NotImplementedException();
        }
    }
}
