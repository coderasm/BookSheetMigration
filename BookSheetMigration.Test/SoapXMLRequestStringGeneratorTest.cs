using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BookSheetMigration.Test
{
    [TestClass]
    public class SoapXMLRequestStringGeneratorTest
    {
        [TestMethod]
        public void WhenGivenASoapOperation_AnXMLStringIsBuilt()
        {
            SoapOperation soapOperation = new SoapOperation("anoperation");
            soapOperation.addPairToOperation("password", "mypassword");
            soapOperation.addPairToOperation("username", "myusername");
            soapOperation.addPairToOperation("securitytoken", "mysecuritytoken");
            String soapXMLStringExpected = @"<?xml version=""1.0"" encoding=""utf-8""?>" +
                                            @"<soap:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance""" +
                                            @"xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">" +
                                                "<soap:Body>";
            SoapXMLRequestStringGenerator soapXmlRequestStringGenerator = new SoapXMLRequestStringGenerator(soapOperation);
            String soapRequestString = soapXmlRequestStringGenerator.generate();
        }
    }
}
