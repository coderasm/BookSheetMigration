using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BookSheetMigration.Test
{
    [TestClass]
    public class SoapRequestMessageBuilderTest
    {
        [TestMethod]
        public void WhenARequestIsBuilt_ThenARequestInstanceIsReturned()
        {
            var action = "myaction";
            var actionArguments = new Dictionary<string, string>()
            {
                {"EventStatus", "Upcoming"}
            };
            var soapRequestMessageBuilder = new SoapRequestMessageBuilder(action, actionArguments);
            SoapRequestMessage soapRequestMessage = soapRequestMessageBuilder.buildSoapRequestMessage();
            Assert.IsNotNull(soapRequestMessage);
        }
    }
}
