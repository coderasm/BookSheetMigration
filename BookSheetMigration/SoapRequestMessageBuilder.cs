using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Xml;

namespace BookSheetMigration
{
    public class SoapRequestMessageBuilder
    {
        private string action;
        private Dictionary<string, string> actionArguments;

        public SoapRequestMessageBuilder(string action, Dictionary<string, string> actionArguments)
        {
            this.action = action;
            this.actionArguments = actionArguments;
        }

        public SoapRequestMessage buildSoapRequestMessage()
        {
            HttpRequestMessage soapRequestMessage = buildRequestMessage(action);
            return new SoapRequestMessage(soapRequestMessage);
        }

        private HttpRequestMessage buildRequestMessage(string action)
        {
            var httpRequest = createHttpRequestAndAddHeaders(action);
            var soapAction = buildSoapActionAndAddParameters(action);
            var requestXmlDocument = createRequestXmlDocument(soapAction);
            return attachPayloadToRequest(requestXmlDocument, httpRequest);
        }

        private SoapAction buildSoapActionAndAddParameters(string action)
        {
            var soapAction = createAction(action);
            addCredentialsToAction(soapAction);
            addSearchCriteriaToAction(soapAction);
            return soapAction;
        }

        private SoapAction createAction(string action)
        {
            return new SoapAction(action, Settings.awgXmlNamespace);
        }

        private void addCredentialsToAction(SoapAction soapAction)
        {
            soapAction.addParameterPairToAction("securityToken", Settings.securityToken);
            soapAction.addParameterPairToAction("clientUsername", Settings.clientUsername);
            soapAction.addParameterPairToAction("clientPassword", Settings.password);
        }

        private void addSearchCriteriaToAction(SoapAction soapAction)
        {
            foreach (var actionArgument in actionArguments)
            {
                soapAction.addParameterPairToAction(actionArgument.Key, actionArgument.Value);
            }
        }

        private HttpRequestMessage createHttpRequestAndAddHeaders(string action)
        {
            var soapRequestMessage = createRequestMessage();
            addHttpHeadersToSoapRequest(soapRequestMessage, action);
            return soapRequestMessage;
        }

        private HttpRequestMessage createRequestMessage()
        {
            return new HttpRequestMessage(HttpMethod.Post, Settings.soapURL);
        }

        private void addHttpHeadersToSoapRequest(HttpRequestMessage requestMessage, string action)
        {
            requestMessage.Headers.Add("SOAPAction", Settings.awgXmlNamespace + "/" + action);
        }

        private HttpRequestMessage attachPayloadToRequest(XmlDocument payload, HttpRequestMessage requestMessage)
        {
            requestMessage.Content = new StringContent(payload.OuterXml, Encoding.UTF8, "text/xml");
            return requestMessage;
        }

        private XmlDocument createRequestXmlDocument(SoapAction soapAction)
        {
            SoapXMLGenerator soapXmlGenerator = new SoapXMLGenerator(soapAction);
            return soapXmlGenerator.generateSoapXmlDocument();
        }
    }
}
