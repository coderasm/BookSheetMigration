using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BookSheetMigration.Test
{
    [TestClass]
    public class SoapHeaderTest
    {
        private SoapHeader soapHeader;

        [TestInitialize]
        public void setUp()
        {
            soapHeader = new SoapHeader();
        }

        [TestMethod]
        public void WhenAddingOnePairToHeader_ThenPairCountIsOne()
        {
            var key = "akey";
            var value = "avalue";
            soapHeader.addPairToHeader(key, value);
            Assert.AreEqual(1, soapHeader.getPairCount());
        }
    }
}
