using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace BookSheetMigration.Test
{
    [TestClass]
    public class SoapXMLRequestStringGeneratorTest
    {
        private const string soapXmlStaticBegin = @"<?xml version=""1.0"" encoding=""utf-8""?>" +
                                                  @"<soap:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance""" +
                                                  @"xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">" +
                                                  "<soap:Body>";

        private const string soapXmlStaticEnd = "</soap:Body>" +
                                                "</soap:Envelope>";

        private SoapAction soapAction;
        private string soapXmlActionBegin;
        private string soapXmlActionEnd;
        private string soapXMLActionParameters;

        [TestInitialize]
        public void setUp()
        {
            soapAction = new SoapAction("anaction", "anamespace");
            soapAction.addPairToAction("password", "mypassword");
            soapAction.addPairToAction("username", "myusername");
            soapAction.addPairToAction("securitytoken", "mysecuritytoken");
            soapXmlActionBegin = @"<" + soapAction.action + @" xmlns=""" + soapAction.xmlnamespace + @""">";
            soapXMLActionParameters = "";
            foreach (var pair in soapAction.soapPairs)
            {
                soapXMLActionParameters += "<" + pair.Key + ">" + pair.Value + "</" + pair.Key + ">";
            }
            soapXmlActionEnd = @"</" + soapAction.action + ">";
        }

        [TestMethod]
        public void WhenGivenASoapAction_AnXMLStringIsBuilt()
        {
            String finalXML = soapXmlStaticBegin + soapXmlActionBegin + soapXMLActionParameters + soapXmlActionEnd + soapXmlStaticEnd;
            SoapXMLRequestStringGenerator soapXmlRequestStringGenerator = new SoapXMLRequestStringGenerator(soapAction);
            String soapRequestString = soapXmlRequestStringGenerator.generateSoapXML();
            Assert.AreEqual(finalXML, soapRequestString);
        }
    }
}
