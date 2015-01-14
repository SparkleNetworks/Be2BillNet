
namespace Be2BillNet.AspMvcDemo.Domain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Web;

    /// <summary>
    /// Minimalist business layer.
    /// This code is NOT for production use.
    /// Uses a file as database.
    /// </summary>
    public class DataService
    {
        private IDataStore<RootData> store;
        private RootData data;
        private readonly Random random = new Random();

        public DataService(IDataStore<RootData> store)
        {
            this.store = store;
        }

        private RootData Data
        {
            get
            {
                if (this.data == null)
                {
                    this.data = this.store.Read() ?? new RootData();
                }

                return this.data;
            }
        }

        [DataContract]
        public class RootData
        {
            private IList<Transaction1> transaction1 = new List<Transaction1>();
            private IDictionary<string, TransactionResult> bebillTransactions = new Dictionary<string, TransactionResult>();

            /// <summary>
            /// Gets or sets the transactions table.
            /// This is a kind of order transaction table.
            /// </summary>
            [DataMember]
            public IList<Transaction1> Transactions1
            {
                get { return this.transaction1; }
                set { this.transaction1 = value; }
            }

            /// <summary>
            /// Gets or sets the B2B transactions table.
            /// It's quite important to keep track of everything you do with the API.
            /// </summary>
            [DataMember]
            public IDictionary<string, TransactionResult> BebillTransactions
            {
                get { return this.bebillTransactions ?? (this.bebillTransactions = new Dictionary<string, TransactionResult>()); }
                set { this.bebillTransactions = value; }
            }
        }

        public void AddTransaction(Transaction1 transaction)
        {
            using (var session = this.store.Write())
            {
                transaction.DateCreatedUtc = DateTime.UtcNow;
                session.Data.Transactions1.Add(transaction);

                session.Save();
            }
        }

        public IList<Transaction1> GetAllTransactions()
        {
            return this.Data.Transactions1.ToList();
        }

        public Transaction1 CreateRandomTransaction()
        {
            using (var session = this.store.Write())
            {
                var transaction = new Transaction1
                {
                    OrderId = Guid.NewGuid().ToString(),
                    UserId = "123456",
                    UserEmail = "test@test.com",
                    Amount = (decimal)Math.Round(random.Next(100, 15000) / 100D, 2),
                    Description = "Payment with a form",
                    DateCreatedUtc = DateTime.UtcNow,
                };
                session.Data.Transactions1.Add(transaction);

                session.Save();
                return transaction;
            }
        }

        public TransactionResult GetBebillTransaction(string orderId)
        {
            return this.data.BebillTransactions.ContainsKey(orderId)
                ? this.data.BebillTransactions[orderId]
                : null;
        }

        public void SaveBebillTransaction(TransactionResult item)
        {
            using (var session = this.store.Write())
            {
                var stored = session.Data.BebillTransactions.ContainsKey(item.OrderId)
                    ? session.Data.BebillTransactions[item.OrderId] : null;

                if (stored == null)
                {
                    stored = new TransactionResult()
                    {
                        OrderId = item.OrderId,
                    };
                    session.Data.BebillTransactions.Add(item.OrderId, stored);
                }

                stored.UpdateFrom(item);

                session.Save();
            }
        }

        public IList<TransactionResult> GetAllBebillTransactions()
        {
            return this.Data.BebillTransactions.Values.ToList();
        }

        internal BasicResult AddPaymentToTransaction1(string transaction1Id, TransactionResult data)
        {
            if (string.IsNullOrEmpty(transaction1Id))
                throw new ArgumentException("The value cannot be empty", "transaction1Id");
            if (data == null)
                throw new ArgumentNullException("data");

            using (var session = this.store.Write())
            {
                var result = new BasicResult();
                var tran = session.Data.Transactions1.SingleOrDefault(t => t.OrderId == transaction1Id);
                result.Data["Transaction"] = tran;

                if (tran == null)
                {
                    result.Errors.Add(new BasicResultError("Cannot find transaction " + transaction1Id));
                    return result;
                }

                var paymentIds = tran.PaymentIds ?? new List<string>();
                tran.PaymentIds = paymentIds;
                if (paymentIds.Contains(data.OrderId))
                {
                    result.Errors.Add(new BasicResultError("This payment is already associated with this item"));
                    return result;
                }

                if (data.AmountCents != null)
                {
                    paymentIds.Add(data.OrderId);

                    tran.AmountPaid += (data.AmountCents.Value / 100M);
                }

                if (tran.AmountPaid >= tran.Amount)
                {
                    tran.IsPaid = true;
                }

                session.Save();
                result.Succeed = true;
                return result;
            }
        }

        internal BasicResult AddPaymentToTransaction1(string transaction1Id, string paymentId)
        {
            if (string.IsNullOrEmpty(transaction1Id))
                throw new ArgumentException("The value cannot be empty", "transaction1Id");
            if (string.IsNullOrEmpty(paymentId))
                throw new ArgumentException("The value cannot be empty", "paymentId");

            using (var session = this.store.Write())
            {
                var result = new BasicResult();
                var tran = session.Data.Transactions1.SingleOrDefault(t => t.OrderId == transaction1Id);

                if (tran == null)
                {
                    result.Errors.Add(new BasicResultError("Cannot find transaction " + transaction1Id));
                    return result;
                }

                if (tran.PaymentIds != null && tran.PaymentIds.Contains(paymentId))
                {
                    result.Errors.Add(new BasicResultError("Payment " + paymentId + " in already associated with this transaction"));
                    return result;
                }

                tran.PaymentIds = tran.PaymentIds ?? new List<string>();
                tran.PaymentIds.Add(paymentId);

                session.Save();
                result.Succeed = true;
                return result;
            }
        }

        public Transaction1 GetTransaction1(string id)
        {
            return this.Data.Transactions1.SingleOrDefault(t => t.OrderId == id);
        }

        public TransactionResult GetBebillItem(string id)
        {
            return this.Data.BebillTransactions.ContainsKey(id)
                ? this.Data.BebillTransactions[id]
                : null;
        }

        public TransactionResult CreateEmptyBebillitem(string orderId)
        {
            if (string.IsNullOrEmpty(orderId))
                throw new ArgumentException("The value cannot be empty", "orderId");

            using (var session = this.store.Write())
            {
                if (session.Data.BebillTransactions.ContainsKey(orderId))
                    return session.Data.BebillTransactions[orderId];

                var item = new TransactionResult
                {
                    OrderId = orderId,
                };
                session.Data.BebillTransactions.Add(orderId, item);
                session.Save();
                return item;
            }
        }
    }
}
