
namespace Be2BillNet.AspMvcDemo
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
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

        /// <summary>
        /// Creates a <see cref="IDictionary&lt;string, string&gt;"/> containing the values from the current <see cref="NameValueCollection"/>.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <returns></returns>
        public static IDictionary<string, string> ToDictionary(this NameValueCollection collection)
        {
            var list = new Dictionary<string, string>();
            foreach (var item in collection.AllKeys)
            {
                list.Add(item, collection[item]);
            }

            return list;
        }

        /// <summary>
        /// Trims a string to the specified length.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="length">The length.</param>
        /// <returns></returns>
        public static string TrimToLength(this string value, int length)
        {
            if (value == null)
                return null;

            if (value.Length <= length)
                return value;

            return value.Substring(0, length);
        }
    }
}