
namespace Be2BillNet
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Text;
    using Be2BillNet.Internals;

    /// <summary>
    /// The result of a transaction.
    /// </summary>
    [DataContract(Namespace = Names.DataContractNamespace)]
    public class TransactionResult
    {
        public static TransactionResult Create(NameValueCollection collection)
        {
            var response = new TransactionResult
            {
                Alias = collection["ALIAS"],
                CardCode = collection["CARDCODE"],
                CardCountry = collection["CARDCOUNTRY"],
                CardFullName = collection["CARDFULLNAME"],
                CardType = collection["CARDTYPE"],
                CardValidityDate = collection["CARDVALIDITYDATE"],
                ClientEmail = collection["CLIENTEMAIL"],
                ClientIdent = collection["CLIENTIDENT"],
                Currency = collection["CURRENCY"],
                Descriptor = collection["DESCRIPTOR"],
                ExecCode = collection["EXECCODE"],
                ExtraData = collection["EXTRADATA"],
                Hash = collection["HASH"],
                Identifier = collection["IDENTIFIER"],
                Is3DSecure = collection["3DSECURE"],
                Language = collection["LANGUAGE"],
                Message = collection["MESSAGE"],
                OperationType = collection["OPERATIONTYPE"],
                OrderId = collection["ORDERID"],
                TransactionId = collection["TRANSACTIONID"],
                Version = collection["VERSION"],
            };

            {
                decimal value;
                if (decimal.TryParse(collection["AMOUNT"], out value))
                    response.AmountCents = value;
            }

            return response;
        }

        public static TransactionResult Create(Func<string, string> getter)
        {
            var response = new TransactionResult
            {
                Alias = getter("ALIAS"),
                CardCode = getter("CARDCODE"),
                CardCountry = getter("CARDCOUNTRY"),
                CardFullName = getter("CARDFULLNAME"),
                CardType = getter("CARDTYPE"),
                CardValidityDate = getter("CARDVALIDITYDATE"),
                ClientEmail = getter("CLIENTEMAIL"),
                ClientIdent = getter("CLIENTIDENT"),
                Currency = getter("CURRENCY"),
                Descriptor = getter("DESCRIPTOR"),
                ExecCode = getter("EXECCODE"),
                ExtraData = getter("EXTRADATA"),
                Hash = getter("HASH"),
                Identifier = getter("IDENTIFIER"),
                Is3DSecure = getter("3DSECURE"),
                Language = getter("LANGUAGE"),
                Message = getter("MESSAGE"),
                OperationType = getter("OPERATIONTYPE"),
                OrderId = getter("ORDERID"),
                TransactionId = getter("TRANSACTIONID"),
                Version = getter("VERSION"),
            };

            {
                decimal value;
                if (decimal.TryParse(getter("AMOUNT"), out value))
                    response.AmountCents = value;
            }

            return response;
        }

        [DataMember(Name = "IDENTIFIER")]
        public string Identifier { get; set; }

        [DataMember(Name = "OPERATIONTYPE")]
        public string OperationType { get; set; }

        [DataMember(Name = "TRANSACTIONID")]
        public string TransactionId { get; set; }

        [DataMember(Name = "CLIENTIDENT")]
        public string ClientIdent { get; set; }

        [DataMember(Name = "CLIENTEMAIL")]
        public string ClientEmail { get; set; }

        [DataMember(Name = "ORDERID")]
        public string OrderId { get; set; }

        [DataMember(Name = "VERSION")]
        public string Version { get; set; }

        [DataMember(Name = "LANGUAGE")]
        public string Language { get; set; }

        [DataMember(Name = "CURRENCY")]
        public string Currency { get; set; }

        [DataMember(Name = "EXTRADATA")]
        public string ExtraData { get; set; }

        [DataMember(Name = "CARDCODE")]
        public string CardCode { get; set; }

        [DataMember(Name = "CARDCOUNTRY")]
        public string CardCountry { get; set; }

        [DataMember(Name = "CARDVALIDITYDATE")]
        public string CardValidityDate { get; set; }

        [DataMember(Name = "CARDFULLNAME")]
        public string CardFullName { get; set; }

        [DataMember(Name = "CARDTYPE")]
        public string CardType { get; set; }

        [DataMember(Name = "EXECCODE")]
        public string ExecCode { get; set; }

        [DataMember(Name = "MESSAGE")]
        public string Message { get; set; }

        [DataMember(Name = "DESCRIPTOR")]
        public string Descriptor { get; set; }

        [DataMember(Name = "ALIAS")]
        public string Alias { get; set; }

        [DataMember(Name = "AMOUNT")]
        public decimal? AmountCents { get; set; }

        [DataMember(Name = "HASH")]
        public string Hash { get; set; }

        [DataMember(Name = "3DSECURE")]
        public string Is3DSecure { get; set; }

        public override string ToString()
        {
            return this.ExecCode + " T" + this.TransactionId + " O" + this.OrderId;
        }
    }
}
