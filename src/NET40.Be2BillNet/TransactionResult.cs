
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
        private readonly Dictionary<string, object> data = new Dictionary<string, object>();

        [DataMember(Name = "IDENTIFIER")]
        public string Identifier
        {
            get { return this.GetValue<string>("IDENTIFIER"); }
            set { this.SetValue("IDENTIFIER", value); }
        }

        [DataMember(Name = "OPERATIONTYPE")]
        public string OperationType
        {
            get { return this.GetValue<string>("OPERATIONTYPE"); }
            set { this.SetValue("OPERATIONTYPE", value); }
        }

        [DataMember(Name = "TRANSACTIONID")]
        public string TransactionId
        {
            get { return this.GetValue<string>("TRANSACTIONID"); }
            set { this.SetValue("TRANSACTIONID", value); }
        }

        [DataMember(Name = "CLIENTIDENT")]
        public string ClientIdent
        {
            get { return this.GetValue<string>("CLIENTIDENT"); }
            set { this.SetValue("CLIENTIDENT", value); }
        }

        [DataMember(Name = "CLIENTEMAIL")]
        public string ClientEmail
        {
            get { return this.GetValue<string>("CLIENTEMAIL"); }
            set { this.SetValue("CLIENTEMAIL", value); }
        }

        [DataMember(Name = "ORDERID")]
        public string OrderId
        {
            get { return this.GetValue<string>("ORDERID"); }
            set { this.SetValue("ORDERID", value); }
        }

        [DataMember(Name = "VERSION")]
        public string Version
        {
            get { return this.GetValue<string>("VERSION"); }
            set { this.SetValue("VERSION", value); }
        }

        [DataMember(Name = "LANGUAGE")]
        public string Language
        {
            get { return this.GetValue<string>("LANGUAGE"); }
            set { this.SetValue("LANGUAGE", value); }
        }

        [DataMember(Name = "CURRENCY")]
        public string Currency
        {
            get { return this.GetValue<string>("CURRENCY"); }
            set { this.SetValue("CURRENCY", value); }
        }

        [DataMember(Name = "EXTRADATA")]
        public string ExtraData
        {
            get { return this.GetValue<string>("EXTRADATA"); }
            set { this.SetValue("EXTRADATA", value); }
        }

        [DataMember(Name = "CARDCODE")]
        public string CardCode
        {
            get { return this.GetValue<string>("CARDCODE"); }
            set { this.SetValue("CARDCODE", value); }
        }

        [DataMember(Name = "CARDCOUNTRY")]
        public string CardCountry
        {
            get { return this.GetValue<string>("CARDCOUNTRY"); }
            set { this.SetValue("CARDCOUNTRY", value); }
        }

        [DataMember(Name = "CARDVALIDITYDATE")]
        public string CardValidityDate
        {
            get { return this.GetValue<string>("CARDVALIDITYDATE"); }
            set { this.SetValue("CARDVALIDITYDATE", value); }
        }

        [DataMember(Name = "CARDFULLNAME")]
        public string CardFullName
        {
            get { return this.GetValue<string>("CARDFULLNAME"); }
            set { this.SetValue("CARDFULLNAME", value); }
        }

        [DataMember(Name = "CARDTYPE")]
        public string CardType
        {
            get { return this.GetValue<string>("CARDTYPE"); }
            set { this.SetValue("CARDTYPE", value); }
        }

        [DataMember(Name = "EXECCODE")]
        public string ExecCode
        {
            get { return this.GetValue<string>("EXECCODE"); }
            set { this.SetValue("EXECCODE", value); }
        }

        [DataMember(Name = "MESSAGE")]
        public string Message
        {
            get { return this.GetValue<string>("MESSAGE"); }
            set { this.SetValue("MESSAGE", value); }
        }

        [DataMember(Name = "DESCRIPTOR")]
        public string Descriptor
        {
            get { return this.GetValue<string>("DESCRIPTOR"); }
            set { this.SetValue("DESCRIPTOR", value); }
        }

        [DataMember(Name = "ALIAS")]
        public string Alias
        {
            get { return this.GetValue<string>("ALIAS"); }
            set { this.SetValue("ALIAS", value); }
        }

        [DataMember(Name = "AMOUNT")]
        public decimal? AmountCents
        {
            get { return this.GetValue<decimal?>("AMOUNT"); }
            set { this.SetValue("AMOUNT", value); }
        }

        [DataMember(Name = "HASH")]
        public string Hash
        {
            get { return this.GetValue<string>("HASH"); }
            set { this.SetValue("HASH", value); }
        }

        [DataMember(Name = "3DSECURE")]
        public string Is3DSecure
        {
            get { return this.GetValue<string>("3DSECURE"); }
            set { this.SetValue("3DSECURE", value); }
        }

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
            return (this.ExecCode ?? "####") + " T=" + this.TransactionId + " O=" + this.OrderId;
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

        private void SetValue<T>(string key, T value)
        {
            this.data[key] = value;
        }

        private T GetValue<T>(string key)
        {
            if (this.data.ContainsKey(key))
                return (T)this.data[key];
            return default(T);
        }

        public IDictionary<string, string> ToDictionary()
        {
            return this.data
                .Where(x => x.Value != null)
                .ToDictionary(x => x.Key, x => x.Value != null ? x.Value.ToString() : null);
        }
    }
}
