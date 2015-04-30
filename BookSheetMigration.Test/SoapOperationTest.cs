using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.Remoting;
using System.Runtime.Serialization.Formatters;
using System.Security.Cryptography;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookSheetMigration;

namespace BookSheetMigration.Test
{
    [TestClass]
    public class SoapOperationTest
    {

        private SoapOperation soapOperation;

        [TestInitialize]
        public void setUp()
        {
            String operation = "operation";
            soapOperation = new SoapOperation(operation);
        }

        [TestMethod]
        public void WhenAddingOnePairToOperation_ThenPairCountIsOne()
        {
            var key = "akey";
            var value = "avalue";
            soapOperation.addPairToOperation(key, value);
            Assert.AreEqual(1, soapOperation.getPairCount());
        }
    }
}
