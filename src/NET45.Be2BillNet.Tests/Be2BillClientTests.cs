
namespace Be2BillNet.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class Be2BillClientTests
    {
        public static Be2BillConfiguration GetClientConfiguration()
        {
            return new Be2BillConfiguration
            {
                ApiIdentifier = "ApiIdentifier",
                ApiKey = "ApiKeyApiKeyApiKeyApiKey",
            };
        }

        public static Be2BillClient GetClient()
        {
            return new Be2BillClient(GetClientConfiguration());
        }

        #region HASH stuff

        [TestMethod]
        public void HashIsComputedCorrectly0()
        {
            var request = new TransactionRequest();
            request.Add("KEY1", "VALUE1");
            var client = GetClient();
            client.SetHash(request);

            Assert.AreEqual("05b2372310c2897729f9c185517a25168e6891f2c7749329255f494e1483f181", request["HASH"]);
        }

        [TestMethod]
        public void HashIsComputedCorrectly0_Verify()
        {
            var hash = "05b2372310c2897729f9c185517a25168e6891f2c7749329255f494e1483f181";
            var request = new TransactionRequest();
            request.Add("KEY1", "VALUE1");
            var client = GetClient();
            var result = client.VerifyParameters(request, GetClientConfiguration().ApiKey, hash);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void HashIsComputedCorrectly0_EvenWithExistingHash()
        {
            var request = new TransactionRequest();
            request.Add("KEY1", "VALUE1");
            request.Add("HASH", "HASH");
            var client = GetClient();
            client.SetHash(request);

            Assert.AreEqual("05b2372310c2897729f9c185517a25168e6891f2c7749329255f494e1483f181", request["HASH"]);
        }

        [TestMethod]
        public void HashIsComputedCorrectly0_DoesNotHashNonUpperKeys()
        {
            var request = new TransactionRequest();
            request.Add("KEY1", "VALUE1");
            request.Add("yop", "VALUE2");
            var client = GetClient();
            client.SetHash(request);

            Assert.AreEqual("05b2372310c2897729f9c185517a25168e6891f2c7749329255f494e1483f181", request["HASH"]);
        }

        [TestMethod]
        public void HashIsComputedCorrectly1()
        {
            var request = new TransactionRequest();
            request.Add("ORDERID", "VALUE1");
            request.Add("DATE", "VALUE2");
            var client = GetClient();
            client.SetHash(request);

            Assert.AreEqual("b7c312f5d79aebc472d91b7395ba855b00bcfee5e15b13a01af85a9f64737a89", request["HASH"]);
        }

        [TestMethod]
        public void HashIsComputedCorrectly1_Verify()
        {
            var hash = "b7c312f5d79aebc472d91b7395ba855b00bcfee5e15b13a01af85a9f64737a89";
            var request = new TransactionRequest();
            request.Add("ORDERID", "VALUE1");
            request.Add("DATE", "VALUE2");
            var client = GetClient();
            var result = client.VerifyParameters(request, GetClientConfiguration().ApiKey, hash);

            Assert.IsTrue(result);
        }

        #endregion
    }
}
