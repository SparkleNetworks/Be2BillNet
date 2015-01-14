
namespace Be2BillNet.AspMvcDemo.Stuff
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Configuration;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    /// <summary>
    /// Allows in-memory tracing of HTTP requests.
    /// </summary>
    public class LogRequestAttribute : ActionFilterAttribute
    {
        const string IsTemporaryDataEnabled = "IsTemporaryDataEnabled";
        const string contextItemKey = "LogRequestAttribute.HttpRequestModel";
        const string appItemsKey = "LogRequestAttribute.HttpRequestModels";

        /// <summary>
        /// Determines whether tracing is enabled.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        public static bool IsEnabled(HttpContextBase context)
        {
            if (context.Application[IsTemporaryDataEnabled] != null)
            {
                return (bool)context.Application[IsTemporaryDataEnabled];
            }

            var configValue = ConfigurationManager.AppSettings["LogRequestAttribute.IsEnabled"];
            bool value;
            if (bool.TryParse(configValue, out value))
            {
                return value;
            }

            return false;
        }

        /// <summary>
        /// Enables or disables tracing.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="value">if set to <c>true</c> [value].</param>
        public static void SetIsEnabled(HttpContextBase context, bool value)
        {
            context.Application[IsTemporaryDataEnabled] = value;
        }

        /// <summary>
        /// Gets all traced requests.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        public static IList<HttpRequestModel> GetItems(HttpContextBase context)
        {
            var collection = GetOrCreateCollection(context);
            return collection.ToList();
        }

        /// <summary>
        /// Gets the model associated with the current HTTP request.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        public static HttpRequestModel GetModel(HttpContextBase context)
        {
            return GetOrCreateModel(context);
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            var context = filterContext.HttpContext;
            var isTemporaryDataEnabled = IsEnabled(context);

            if (isTemporaryDataEnabled)
            {
                var model = GetOrCreateModel(context);
            }
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);

            var context = filterContext.HttpContext;
            var isTemporaryDataEnabled = IsEnabled(context);

            if (isTemporaryDataEnabled)
            {
                var model = GetOrCreateModel(context);
                var result = filterContext.Result;
                model.ResultType = result.GetType().FullName;
            }
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            base.OnResultExecuted(filterContext);

            var context = filterContext.HttpContext;
            var isTemporaryDataEnabled = IsEnabled(context);

            if (isTemporaryDataEnabled)
            {
                var model = GetOrCreateModel(context);
                var result = filterContext.Result;
                model.ResultHttpCode = context.Response.StatusCode;
            }
        }

        private static HttpRequestModel GetOrCreateModel(HttpContextBase context)
        {
            var collection = GetOrCreateCollection(context);

            var model = (HttpRequestModel)context.Items[contextItemKey];
            if (model == null)
            {
                model = HttpRequestModel.Create(context.Request);
                if (IsEnabled(context))
                {
                    context.Items[contextItemKey] = model;
                }
            }

            if (IsEnabled(context) && !collection.Contains(model))
            {
                collection.Add(model); 
            }

            return model;
        }

        private static List<HttpRequestModel> GetOrCreateCollection(HttpContextBase context)
        {
            var collection = context.Application[appItemsKey] as List<HttpRequestModel>;
            if (collection == null)
            {
                collection = new List<HttpRequestModel>();
                context.Application[appItemsKey] = collection;
            }
            return collection;
        }

        internal static void ClearItems(HttpContextBase context)
        {
            var collection = context.Application[appItemsKey] as List<HttpRequestModel>;
            if (collection != null)
            {
                collection.Clear();
            }
        }
    }

    public class HttpRequestModel
    {
        private List<string> messages;
        private List<string> files;

        public static HttpRequestModel Create(HttpRequestBase httpRequest)
        {
            var model = new HttpRequestModel
            {
                Id = Guid.NewGuid(),
                DateUtc = DateTime.UtcNow,
                Method = httpRequest.HttpMethod,
                Path = httpRequest.RawUrl,
                Headers = string.Join(
                    Environment.NewLine,
                    httpRequest.Headers.AllKeys.Select(k => k + ": " + httpRequest.Headers[k])),
            };
            try
            {
                model.PostContent = httpRequest.Form.Count > 0 
                    ? string.Join(
                        Environment.NewLine,
                        httpRequest.Form.ToDictionary()
                            .Where(x => x.Key != null)
                            .Select(x => x.Key + "=" + x.Value))
                    : null;
            }
            catch (Exception)
            {
            }
            return model;
        }

        public DateTime DateUtc { get; set; }

        public string Method { get; set; }

        public string Path { get; set; }

        public string Headers { get; set; }

        public string PostContent { get; set; }

        public Guid Id { get; set; }

        public byte[] PostBytes { get; set; }

        public List<string> Messages
        {
            get { return this.messages ?? (this.messages = new List<string>()); }
        }

        public List<string> Files
        {
            get { return this.files ?? (this.files = new List<string>()); }
        }

        public string ResultType { get; set; }

        public int ResultHttpCode { get; set; }
    }
}
