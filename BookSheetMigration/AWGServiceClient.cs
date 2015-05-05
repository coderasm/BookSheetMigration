using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.ServiceModel;
using System.Text;
using System.Xml;

namespace BookSheetMigration
{
    public class AWGServiceClient
    {
        private SoapOperation soapOperation;
        private IDictionary<string, string> actionArguments;
        private HttpRequestMessage soapRequestMessage;

        public AWGServiceClient()
        {
            actionArguments = new Dictionary<string, string>();
        }

        public EventDTO findEventsByStatus(string eventStatus)
        {
            string action = "ListEvent";
            actionArguments.Add("eventStatus", eventStatus);
            buildSoapOperation(action);

            createSoapXMLRequestString();

            createAndAddHeadersToRequest(action);
            attachPayloadToRequest(soapOperation);
            sendRequest();

            return new EventDTO();
        }

        private void buildSoapOperation(string action)
        {
            createOperation(action);
            addCredentialsToOperation();
            addSearchCriteriaToOperation();
        }

        private void createOperation(string action)
        {
            soapOperation = new SoapOperation(action, Settings.awgXMLNamespace);
        }

        private void addCredentialsToOperation()
        {
            soapOperation.addPairToAction("securityToken", Settings.securityToken);
            soapOperation.addPairToAction("clientUsername", Settings.clientUsername);
            soapOperation.addPairToAction("clientPassword", Settings.password);
        }

        private void addSearchCriteriaToOperation()
        {
            foreach (var actionArgument in actionArguments)
            {
                soapOperation.addPairToAction(actionArgument.Key, actionArgument.Value);
            }
        }

        private XmlDocument createSoapXMLRequestString()
        {
            SoapXMLGenerator soapXmlGenerator = new SoapXMLGenerator(soapOperation);
            return soapXmlGenerator.generateSoapXmlDocument();
        }

        private void createAndAddHeadersToRequest(string action)
        {
            var requestMessage = createRequestMessage();
            addHttpHeadersToSoapRequest(requestMessage, action);
        }

        private HttpRequestMessage createRequestMessage()
        {
            return new HttpRequestMessage(HttpMethod.Post, Settings.soapURL);
        }

        private void addHttpHeadersToSoapRequest(HttpRequestMessage requestMessage, string action)
        {
            requestMessage.Headers.Add("SOAPAction", Settings.awgXMLNamespace + action);
        }

        private void attachPayloadToRequest(SoapOperation soapOperation)
        {
            
        }

        private void sendRequest()
        {
            throw new NotImplementedException();
        }
    }
}
