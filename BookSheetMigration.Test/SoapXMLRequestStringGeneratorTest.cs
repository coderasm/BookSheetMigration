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

        private SoapOperation _soapOperation;
        private string soapXmlActionBegin;
        private string soapXmlActionEnd;
        private string soapXMLActionParameters;

        [TestInitialize]
        public void setUp()
        {
            _soapOperation = new SoapOperation("anaction", "anamespace");
            _soapOperation.addPairToAction("password", "mypassword");
            _soapOperation.addPairToAction("username", "myusername");
            _soapOperation.addPairToAction("securitytoken", "mysecuritytoken");
            soapXmlActionBegin = @"<" + _soapOperation.Operation + @" xmlns=""" + _soapOperation.xmlnamespace + @""">";
            soapXMLActionParameters = "";
            foreach (var pair in _soapOperation.parameters)
            {
                soapXMLActionParameters += "<" + pair.Key + ">" + pair.Value + "</" + pair.Key + ">";
            }
            soapXmlActionEnd = @"</" + _soapOperation.Operation + ">";
        }

        [TestMethod]
        public void WhenGivenASoapAction_AnXMLStringIsBuilt()
        {
            String finalXML = soapXmlStaticBegin + soapXmlActionBegin + soapXMLActionParameters + soapXmlActionEnd + soapXmlStaticEnd;
            SoapXMLGenerator soapXmlGenerator = new SoapXMLGenerator(_soapOperation);
            String soapRequestString = soapXmlGenerator.generateSoapXmlDocument().OuterXml;
            Assert.AreEqual(finalXML, soapRequestString);
        }
    }
}
