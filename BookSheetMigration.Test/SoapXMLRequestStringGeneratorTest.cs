using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace BookSheetMigration.Test
{
    [TestClass]
    public class SoapXMLRequestStringGeneratorTest
    {
        [TestMethod]
        public void WhenGivenASoapAction_AnXMLStringIsBuilt()
        {
            SoapAction soapAction = new SoapAction("anaction", "anamespace");
            soapAction.addPairToOperation("password", "mypassword");
            soapAction.addPairToOperation("username", "myusername");
            soapAction.addPairToOperation("securitytoken", "mysecuritytoken");
            String soapXMLStaticBegin = @"<?xml version=""1.0"" encoding=""utf-8""?>" +
                                        @"<soap:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance""" +
                                        @"xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">" +
                                            "<soap:Body>";
            String soapXMLActionBegin = @"<" + soapAction.action + @" xmlns=""" + soapAction.xmlnamespace + @""">";
            String soapXMLActionParameters = "";
            foreach (var pair in soapAction.soapPairs)
            {
                soapXMLActionParameters += "<" + pair.Key + ">" + pair.Value + "</" + pair.Key + ">";
            }
            String soapXMLActionEnd = @"</" + soapAction.action + ">";
            String soapXMLStaticEnd = "</soap:Body>" +
                                    "</soap:Envelope>";
            String finalXML = soapXMLStaticBegin + soapXMLActionBegin + soapXMLActionParameters + soapXMLActionEnd + soapXMLStaticEnd;

            SoapXMLRequestStringGenerator soapXmlRequestStringGenerator = new SoapXMLRequestStringGenerator(soapAction);
            String soapRequestString = soapXmlRequestStringGenerator.generateSoapXML();
            Assert.AreEqual(finalXML, soapRequestString);
        }
    }
}
