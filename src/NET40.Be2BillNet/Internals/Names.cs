
namespace Be2BillNet.Internals
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    internal static class Names
    {
        /// <summary>
        /// The internal data contract namespace for serialization.
        /// </summary>
        internal const string DataContractNamespace = "http://be2billnet.com/data/";

        internal const string ApiVersion = "2.0";

        internal static class Params
        {
            internal const string Hash = "HASH";
            internal const string OperationType = "OPERATIONTYPE";
            internal const string Description = "DESCRIPTION";
            internal const string OrderId = "ORDERID";
            internal const string Amount = "AMOUNT";
            internal const string Version = "VERSION";
            internal const string ClientIdent = "CLIENTIDENT";
            internal const string Language = "LANGUAGE";
            internal const string CreateAlias = "CREATEALIAS";
            internal const string DisplayCreateAlias = "DISPLAYCREATEALIAS";
            internal const string Identifier = "IDENTIFIER";
            internal const string ClientEmail = "CLIENTEMAIL";
            internal const string Use3DSecure = "3DSECURE";
            internal const string HideClientEmail = "HIDECLIENTEMAIL";
            internal const string Alias = "ALIAS";
            internal const string AliasMode = "ALIASMODE";
            internal const string ClientIP = "CLIENTIP";
            internal const string ClientUserAgent = "CLIENTUSERAGENT";

            internal const string Yes = "yes";
            internal const string No = "no";
            internal const string OperationTypeAuthorization = "authorization";
            internal const string OperationTypePayment = "payment";
            internal const string AliasModeOneClick = "oneclick";
        }
    }
}
