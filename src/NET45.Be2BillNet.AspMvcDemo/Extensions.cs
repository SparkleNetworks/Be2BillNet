
namespace Be2BillNet.AspMvcDemo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using Be2BillNet.AspMvcDemo.Domain;

    public static class Extensions
    {
        public static DataService GetDomain(this HttpContext context)
        {
            var item = (DataService)context.Items["DataService"];
            if (item == null)
            {
                var store = new JsonFileDataStore<DataService.RootData>(context.Server.MapPath("~/App_Data/data.json"));
                item = new DataService(store);
                context.Items["DataService"] = item;
            }

            return item;
        }

        public static DataService GetDomain(this HttpContextBase context)
        {
            var item = (DataService)context.Items["DataService"];
            if (item == null)
            {
                var store = new JsonFileDataStore<DataService.RootData>(context.Server.MapPath("~/App_Data/data.json"));
                item = new DataService(store);
                context.Items["DataService"] = item;
            }

            return item;
        }

        /// <summary>
        /// Create the left part of a URL based on a HTTP request.
        /// </summary>
        /// <param name="httpRequest"></param>
        /// <returns></returns>
        public static string Compose(this HttpRequestBase httpRequest)
        {
            string url = httpRequest.IsSecureConnection ? "https://" : "http://";

            url += httpRequest.ServerVariables["SERVER_NAME"];

            if (httpRequest.ServerVariables["SERVER_PORT"] == "443" && httpRequest.IsSecureConnection || httpRequest.ServerVariables["SERVER_PORT"] == "80" && !httpRequest.IsSecureConnection)
            {
            }
            else
            {
                url += ":" + httpRequest.ServerVariables["SERVER_PORT"];
            }

            return url;
        }
    }
}