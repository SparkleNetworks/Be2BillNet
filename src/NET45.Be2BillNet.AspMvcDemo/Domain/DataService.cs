
namespace Be2BillNet.AspMvcDemo.Domain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Web;

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

            [DataMember]
            public IList<Transaction1> Transactions1
            {
                get { return this.transaction1; }
                set { this.transaction1 = value; }
            }
        }

        public void AddTransaction(Transaction1 transaction)
        {
            using (var session = this.store.Write())
            {
                transaction.DateCreatedUtc = DateTime.UtcNow;
                session.Data.Transactions1.Add(transaction);
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
                return transaction;
            }
        }
    }
}
