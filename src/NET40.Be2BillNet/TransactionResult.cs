
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

        public static TransactionResult Create(NameValueCollection collection)
        {
            return Create(key => collection[key]);
        }

        public static TransactionResult Create(Func<string, string> getter)
        {
            var item = new TransactionResult();
            Update(item, getter);
            return item;
        }

        public override string ToString()
        {
            return this.ExecCode + " T" + this.TransactionId + " O" + this.OrderId;
        }

        public void UpdateFrom(TransactionResult item)
        {
            if (item == null)
                throw new ArgumentNullException("item");

            if (this.OrderId != item.OrderId)
                throw new ArgumentException("The OrderId must be the same for this operation", "item.OrderId");

            Update(this, item);
        }

        private static void Update(TransactionResult item, TransactionResult update)
        {
            if (item == null)
                throw new ArgumentNullException("item");
            if (update == null)
                throw new ArgumentNullException("update");

            item.Alias = update.Alias;
            item.AmountCents = update.AmountCents;
            item.CardCode = update.CardCode;
            item.CardCountry = update.CardCountry;
            item.CardFullName = update.CardFullName;
            item.CardType = update.CardType;
            item.CardValidityDate = update.CardValidityDate;
            item.ClientEmail = update.ClientEmail;
            item.ClientIdent = update.ClientIdent;
            item.Currency = update.Currency;
            item.Descriptor = update.Descriptor;
            item.ExecCode = update.ExecCode;
            item.ExtraData = update.ExtraData;
            item.Hash = update.Hash;
            item.Identifier = update.Identifier;
            item.Is3DSecure = update.Is3DSecure;
            item.Language = update.Language;
            item.Message = update.Message;
            item.OperationType = update.OperationType;
            item.OrderId = update.OrderId;
            item.TransactionId = update.TransactionId;
            item.Version = update.Version;
        }

        private static void Update(TransactionResult item, Func<string, string> getter)
        {
            if (item == null)
                throw new ArgumentNullException("item");
            if (getter == null)
                throw new ArgumentNullException("getter");

            item.Alias = getter("ALIAS");
            item.CardCode = getter("CARDCODE");
            item.CardCountry = getter("CARDCOUNTRY");
            item.CardFullName = getter("CARDFULLNAME");
            item.CardType = getter("CARDTYPE");
            item.CardValidityDate = getter("CARDVALIDITYDATE");
            item.ClientEmail = getter("CLIENTEMAIL");
            item.ClientIdent = getter("CLIENTIDENT");
            item.Currency = getter("CURRENCY");
            item.Descriptor = getter("DESCRIPTOR");
            item.ExecCode = getter("EXECCODE");
            item.ExtraData = getter("EXTRADATA");
            item.Hash = getter("HASH");
            item.Identifier = getter("IDENTIFIER");
            item.Is3DSecure = getter("3DSECURE");
            item.Language = getter("LANGUAGE");
            item.Message = getter("MESSAGE");
            item.OperationType = getter("OPERATIONTYPE");
            item.OrderId = getter("ORDERID");
            item.TransactionId = getter("TRANSACTIONID");
            item.Version = getter("VERSION");

            {
                decimal value;
                if (decimal.TryParse(getter("AMOUNT"), out value))
                    item.AmountCents = value;
            }
        }
    }
}
