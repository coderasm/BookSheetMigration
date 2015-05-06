using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BookSheetMigration.Test
{
    [TestClass]
    public class SoapOperationTest
    {

        private SoapAction _soapAction;

        [TestInitialize]
        public void setUp()
        {
            String action = "operation";
            String xmlnamespace = "actionNamespace";
            _soapAction = new SoapAction(action, xmlnamespace);
        }

        [TestMethod]
        public void WhenAddingOnePairToOperation_ThenPairCountIsOne()
        {
            var key = "akey";
            var value = "avalue";
            _soapAction.addParameterPairToAction(key, value);
            Assert.AreEqual(1, _soapAction.getPairCount());
        }
    }
}
