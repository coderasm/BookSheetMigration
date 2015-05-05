using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BookSheetMigration.Test
{
    [TestClass]
    public class SoapOperationTest
    {

        private SoapOperation _soapOperation;

        [TestInitialize]
        public void setUp()
        {
            String action = "operation";
            String xmlnamespace = "xmlnamespace";
            _soapOperation = new SoapOperation(action, xmlnamespace);
        }

        [TestMethod]
        public void WhenAddingOnePairToOperation_ThenPairCountIsOne()
        {
            var key = "akey";
            var value = "avalue";
            _soapOperation.addPairToAction(key, value);
            Assert.AreEqual(1, _soapOperation.getPairCount());
        }
    }
}
