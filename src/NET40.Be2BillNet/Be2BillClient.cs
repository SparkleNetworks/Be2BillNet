
namespace Be2BillNet
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Runtime.Serialization.Json;
    using System.Security.Cryptography;
    using System.Text;
    using Be2BillNet.Internals;

    /// <summary>
    /// The client for Be2Bill operations.
    /// </summary>
    public class Be2BillClient
    {
        private readonly Be2BillConfiguration configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="Be2BillClient"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public Be2BillClient(Be2BillConfiguration configuration)
        {
            this.configuration = configuration;
        }

        internal Be2BillConfiguration Configuration
        {
            get { return this.configuration; }
        }

        /// <summary>
        /// Gets the hash for the collection of parameters.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="pass">The pass.</param>
        /// <param name="unhashed">The unhashed.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">collection</exception>
        public string GetHashForParameters(IDictionary<string, string> collection, string pass, out string unhashed)
        {
            if (collection == null)
                throw new ArgumentNullException("collection");

            // http://developer.be2bill.com/platform.html#c3

            // filter and sort dictionary
            collection = collection
                .Where(p => p.Key != null && p.Key.Length > 0 // hu?
                         && p.Key.ToUpperInvariant() == p.Key // all b2b keys are uppercase
                         && p.Key != Names.Params.Hash)       // exclude some keys
                .OrderBy(x => x.Key)
                .ToDictionary(p => p.Key, p => p.Value);

            using (var sha = new SHA256Managed()) // maybe put that as instance field?
            {
                unhashed = pass + string.Join(pass, collection.Select(x => x.Key + "=" + x.Value)) + pass;
                var keyBytes = Encoding.UTF8.GetBytes(unhashed);
                var hash = sha.ComputeHash(keyBytes);

                // the ToLower is important because .NET returns uppercase letters and b2b returns "Invalid HASH" in this case.
                var hashString = BitConverter.ToString(hash).Replace("-", string.Empty).ToLowerInvariant();

                ////Debug.WriteLine(DateTime.UtcNow.ToString("o") + " Be2BillClient.GetHashForParameters " + Environment.NewLine + unhashed + Environment.NewLine + hashString);

                return hashString;
            }
        }

        /// <summary>
        /// Verifies the hash for the collection of parameters.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="pass">The pass.</param>
        /// <param name="hash">The hash to verify (you can pass null if the hash is in the collection).</param>
        /// <returns>true if the hash matches; otherwise, false</returns>
        public bool VerifyParameters(IDictionary<string, string> collection, string pass, string hash)
        {
            if (hash == null)
            {
                if (collection.ContainsKey(Names.Params.Hash))
                {
                    hash = collection[Names.Params.Hash];
                }
            }

            string collectionHashString;
            var collectionHash = this.GetHashForParameters(collection, pass, out collectionHashString);
            return collectionHash.ToLowerInvariant().Equals(hash.ToLowerInvariant());
        }

        /// <summary>
        /// Creates the authorization/payment parameters. You have to call SetPayWithForm or SetPayWithAlias after.
        /// </summary>
        /// <param name="uniqueOrderId">The unique order unique identifier (you have to create it).</param>
        /// <param name="userId">The user unique identifier.</param>
        /// <param name="userEmail">The user email.</param>
        /// <param name="description">The description of the payment.</param>
        /// <param name="amountInEuro">The amount information euro (not in cents).</param>
        /// <param name="createAlias">if set to <c>true</c> [create alias] (to do oneclick later).</param>
        /// <param name="displayCreateAlias">if set to <c>true</c> the payment form will ask whether to save the card information.</param>
        /// <param name="authorizationInsteadOfPayment">if set to <c>true</c> [authorization instead of payment].</param>
        /// <param name="language">The language.</param>
        /// <returns></returns>
        public IDictionary<string, string> CreateAuthorizationParameters(
            string uniqueOrderId,
            string userId,
            string userEmail,
            string description,
            decimal amountInEuro,
            bool createAlias = false,
            bool displayCreateAlias = false,
            bool authorizationInsteadOfPayment = false,
            Be2BillLanguage language = Be2BillLanguage.EN)
        {
            // http://developer.be2bill.com/platform

            var collection = new Dictionary<string, string>();

            if (authorizationInsteadOfPayment)
            {
                collection.Add(Names.Params.OperationType, Names.Params.OperationTypeAuthorization);
            }
            else
            {
                collection.Add(Names.Params.OperationType, Names.Params.OperationTypePayment);
            }

            collection.Add(Names.Params.Description, description);
            collection.Add(Names.Params.OrderId, uniqueOrderId); // be2bill seems to accept only 1 tentative per ORDERID
            collection.Add(Names.Params.Amount, Math.Round(amountInEuro * 100).ToString());
            collection.Add(Names.Params.Version, Names.ApiVersion);
            collection.Add(Names.Params.ClientIdent, userId);
            collection.Add(Names.Params.Language, language.ToString());

            if (createAlias)
            {
                collection.Add(Names.Params.CreateAlias, Names.Params.Yes); // allow one-click for later transactions (force)
            }

            if (displayCreateAlias)
            {
                collection.Add(Names.Params.DisplayCreateAlias, Names.Params.Yes); // allow one-click for later transactions (ask user)
            }

            collection.Add(Names.Params.Identifier, configuration.ApiIdentifier);

            if (userEmail != null)
            {
                collection.Add(Names.Params.ClientEmail, userEmail);
            }

            return collection;
        }

        /// <summary>
        /// Sets the pay with form. Call CreateAuthorizationParameters first.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="allow3dSecure">if set to <c>true</c> [allow3d secure].</param>
        /// <param name="hideClientEmail">if set to <c>true</c> [hide client email].</param>
        /// <exception cref="System.ArgumentNullException">collection</exception>
        public void SetPayWithForm(
            IDictionary<string, string> collection,
            bool allow3dSecure = true,
            bool hideClientEmail = false)
        {
            if (collection == null)
                throw new ArgumentNullException("collection");

            collection.Add(Names.Params.Use3DSecure, allow3dSecure ? Names.Params.Yes : Names.Params.No);
            collection.Add(Names.Params.HideClientEmail, hideClientEmail ? Names.Params.Yes : Names.Params.No);
        }

        /// <summary>
        /// Sets the pay with alias. Call CreateAuthorizationParameters first.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="alias">The alias.</param>
        /// <param name="userAddress">The user address.</param>
        /// <param name="userAgent">The user agent.</param>
        /// <exception cref="System.ArgumentNullException">collection</exception>
        /// <exception cref="System.ArgumentException">
        /// The value cannot be empty;alias
        /// or
        /// The value cannot be empty;userAddress
        /// or
        /// The value cannot be empty;userAgent
        /// </exception>
        public void SetPayWithAlias(IDictionary<string, string> collection, string alias, string userAddress, string userAgent)
        {
            if (collection == null)
                throw new ArgumentNullException("collection");
            if (string.IsNullOrEmpty(alias))
                throw new ArgumentException("The value cannot be empty", "alias");
            if (string.IsNullOrEmpty(userAddress))
                throw new ArgumentException("The value cannot be empty", "userAddress");
            if (string.IsNullOrEmpty(userAgent))
                throw new ArgumentException("The value cannot be empty", "userAgent");

            collection.Add(Names.Params.Alias, alias);
            collection.Add(Names.Params.AliasMode, Names.Params.AliasModeOneClick);
            collection.Add(Names.Params.ClientIP, userAddress);
            collection.Add(Names.Params.ClientUserAgent, userAgent);

            // some keys are not allowed when paying with alias
            string[] removeKeys = new string[]
            {
                Names.Params.Language,
                Names.Params.Use3DSecure,
                Names.Params.HideClientEmail,
            };
            foreach (var key in removeKeys)
            {
                if (collection.ContainsKey(key))
                    collection.Remove(key);
            }
        }

        /// <summary>
        /// Call the API to pay with an alias.
        /// </summary>
        /// <param name="collection">The collection from CreateAuthorizationParameters.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">
        /// collection
        /// </exception>
        /// <exception cref="Be2BillApiException"></exception>
        public TransactionResult PayWithAlias(IDictionary<string, string> collection)
        {
            if (collection == null)
                throw new ArgumentNullException("collection");

            var serializableData = new Dictionary<string, object>();
            var nonSerializableData = new Dictionary<string, object>();

            // prepare request
            var requestModel = new Be2BillRestRequest
            {
                Method = collection[Names.Params.OperationType],
                Params = collection,
            };
            var postStringBuilder = new StringBuilder();
            postStringBuilder.Append("method=" + Uri.EscapeDataString(collection[Names.Params.OperationType]));
            foreach (var item in collection)
            {
                postStringBuilder.Append("&params[");
                postStringBuilder.Append(Uri.EscapeDataString(item.Key));
                postStringBuilder.Append("]=");
                postStringBuilder.Append(Uri.EscapeDataString(item.Value));
            }

            var postString = postStringBuilder.ToString();
            var postBytes = Encoding.UTF8.GetBytes(postString);

            var request = (HttpWebRequest)HttpWebRequest.Create(configuration.RestUrl);
            request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
            request.ContentLength = postBytes.Length;
            request.Method = "POST";
            request.UserAgent = "Be2BillNet/1.0";
            nonSerializableData.Add("HttpRequest", request);
            serializableData.Add("HttpRequest.PostText", postString);

            ////Trace.TraceWarning(DateTime.UtcNow.ToString("o") + " Be2BillClient.PayWithAlias Request details for " + configuration.RestUrl + Environment.NewLine + 
            ////    request.Method + " " + request.RequestUri.PathAndQuery + Environment.NewLine +
            ////    string.Join(Environment.NewLine, request.Headers.ToDictionary().Select(p => p.Key + ": " + p.Value)) + Environment.NewLine +
            ////    Environment.NewLine +
            ////    postString + Environment.NewLine);

            // send request
            try
            {
                var writeStream = request.GetRequestStream();
                writeStream.Write(postBytes, 0, postBytes.Length);
                writeStream.Flush();
                writeStream.Close();
            }
            catch (Exception ex)
            {
                throw Be2BillApiException.Create(1, "Failed to send API request", ex, serializableData, nonSerializableData);
            }

            // get response
            HttpWebResponse response;
            TransactionResult result = null;
            try
            {
                response = (HttpWebResponse)request.GetResponse();
                nonSerializableData.Add("HttpResponse", response);
                var readStream = response.GetResponseStream();
                ////var reader = new StreamReader(readStream, Encoding.UTF8);
                ////json = reader.ReadToEnd();
                ////serializableData.Add("HttpResponse.Text", json);

                ////#warning REMOVE THIS DEBUGGING LINE
                ////Trace.TraceWarning(DateTime.UtcNow.ToString("o") + " Be2BillClient.PayWithAlias Response details for " + configuration.RestUrl + Environment.NewLine +
                ////    string.Join(Environment.NewLine, response.Headers.ToDictionary().Select(p => p.Key + ": " + p.Value)) + Environment.NewLine +
                ////    Environment.NewLine +
                ////    json + Environment.NewLine);

                // read response content
                try
                {
                    var serializer = new DataContractJsonSerializer(typeof(TransactionResult));
                    result = (TransactionResult)serializer.ReadObject(readStream);
                    nonSerializableData.Add("Result", result);
                }
                catch (Exception ex)
                {
                    throw Be2BillApiException.Create(2, "Failed to read API response", ex, serializableData, nonSerializableData);
                }

                // check HTTP code
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw Be2BillApiException.Create(3, "Be2Bill API returned HTTP Code " + (int)response.StatusCode + " " + response.StatusCode, null, serializableData, nonSerializableData);
                }
            }
            catch (WebException ex)
            {
                response = (HttpWebResponse)ex.Response;

                throw Be2BillApiException.Create(4, "Failed to get API response", ex, serializableData, nonSerializableData);
            }

            if (result == null)
            {
                throw Be2BillApiException.Create(6, "Be2Bill API returned a empty response ", null, serializableData, nonSerializableData);
            }

            serializableData.Add("Result.ExecCode", result.ExecCode);
            if (result.ExecCode == "1005")
            {
                throw Be2BillApiException.Create(7, "Be2Bill API returned EXEC Code (" + result.ExecCode + ") " + Be2BillUtility.GetNameForExecCode(result.ExecCode, CultureInfo.CurrentCulture) + " '" + result.Message + "'", null, serializableData, nonSerializableData);
            }

            return result;
        }

        /// <summary>
        /// Sets the authenticity hash in the collection of data.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <exception cref="System.ArgumentNullException">collection</exception>
        public void SetHash(IDictionary<string, string> collection)
        {
            if (collection == null)
                throw new ArgumentNullException("collection");

            string unhashed;
            var hash = this.GetHashForParameters(collection, configuration.ApiKey, out unhashed);
            collection.Add("HASH", hash);
        }
    }
}
