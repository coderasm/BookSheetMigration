using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BookSheetMigration.Test
{
    [TestClass]
    public class SoapOperationTest
    {

        private SoapAction soapAction;

        [TestInitialize]
        public void setUp()
        {
            String action = "action";
            String xmlnamespace = "xmlnamespace";
            soapAction = new SoapAction(action, xmlnamespace);
        }

        [TestMethod]
        public void WhenAddingOnePairToOperation_ThenPairCountIsOne()
        {
            var key = "akey";
            var value = "avalue";
            soapAction.addPairToAction(key, value);
            Assert.AreEqual(1, soapAction.getPairCount());
        }
    }
}
