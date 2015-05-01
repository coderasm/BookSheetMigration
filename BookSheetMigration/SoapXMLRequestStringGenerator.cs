namespace BookSheetMigration
{
    public class SoapXMLRequestStringGenerator
    {
        private const string soapXmlStaticBegin = @"<?xml version=""1.0"" encoding=""utf-8""?>" +
                                                  @"<soap:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance""" +
                                                  @"xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">" +
                                                   "<soap:Body>";

        private const string soapXmlStaticEnd = "</soap:Body>" +
                                                "</soap:Envelope>";

        private SoapAction soapAction;

        public SoapXMLRequestStringGenerator(SoapAction soapAction)
        {
            this.soapAction = soapAction;
        }

        public string generateSoapXML()
        {
            var soapXMLActionBegin = generateSoapActionOpenTag();
            var soapXMLActionParameters = generatXMLForActionParameters();
            var soapXMLActionEnd = generateSoapActionCloseTag();
            return soapXmlStaticBegin +
                   soapXMLActionBegin +
                   soapXMLActionParameters +
                   soapXMLActionEnd +
                   soapXmlStaticEnd;
        }

        private string generateSoapActionOpenTag()
        {
            var soapXMLActionBegin = @"<" + soapAction.action + @" xmlns=""" + soapAction.xmlnamespace + @""">";
            return soapXMLActionBegin;
        }

        private string generatXMLForActionParameters()
        {
            var soapXMLActionParameters = "";
            foreach (var pair in soapAction.soapPairs)
            {
                soapXMLActionParameters += "<" + pair.Key + ">" + pair.Value + "</" + pair.Key + ">";
            }
            return soapXMLActionParameters;
        }

        private string generateSoapActionCloseTag()
        {
            var soapXMLActionEnd = @"</" + soapAction.action + ">";
            return soapXMLActionEnd;
        }
    }
}
