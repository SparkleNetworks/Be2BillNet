
namespace Be2BillNet.Tests
{
    using System;
    using System.IO;
    using System.Runtime.Serialization.Json;
    using Be2BillNet;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TransactionResultTests
    {
        private static readonly Random random = new Random();

        public static TransactionResult GetRandomTransactionResult()
        {
            return new TransactionResult
            {
                OrderId = Guid.NewGuid().ToString(),
                Alias = Guid.NewGuid().ToString(),
                AmountCents = (decimal)Math.Round(random.Next(100, 15000) / 100D, 2),
                CardCode = "1234 5678 9012 3456",
                CardCountry = "FR",
                CardFullName = "John Smith",
                CardType = "VISA",
                CardValidityDate = "01/89",
                ClientEmail = "test@test.com",
                ClientIdent = "479646574",
                Currency = "EUR",
                Descriptor = Guid.NewGuid().ToString(),
                ExecCode = "0000",
                ExtraData = "hello world",
                Hash = "0123456789azertyuiopqsdfghjklmwxcvbn",
                Identifier = "???",
                Is3DSecure = "0",
                Language = "FR",
                Message = "message",
                OperationType = "authorize",
                TransactionId = Guid.NewGuid().ToString(),
                Version = "2",
            };
        }

        [TestMethod]
        public void UpdateMethodUpdatesAllFields()
        {
            var item = GetRandomTransactionResult();
            var copy = new TransactionResult
            {
                OrderId = item.OrderId,
            };
            copy.UpdateFrom(item);

            var serializer = new DataContractJsonSerializer(item.GetType());

            var mem1 = new MemoryStream();
            var mem2 = new MemoryStream();
            serializer.WriteObject(mem1, item);
            serializer.WriteObject(mem2, copy);
            mem1.Seek(0L, SeekOrigin.Begin);
            mem2.Seek(0L, SeekOrigin.Begin);
            var str1 = new StreamReader(mem1).ReadToEnd();
            var str2 = new StreamReader(mem2).ReadToEnd();
            Assert.AreEqual(str1, str2);
        }
    }
}
