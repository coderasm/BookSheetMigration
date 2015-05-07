using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace BookSheetMigration
{
    public class AWGServiceClient
    {
        private readonly IDictionary<string, string> actionArguments;

        public AWGServiceClient()
        {
            actionArguments = new Dictionary<string, string>();
        }

        public AWGEventDirectory findEventsByStatus(EventStatus eventStatus)
        {
            string action = "ListEvent";
            actionArguments.Add("eventStatus", eventStatus.ToString());
            return (AWGEventDirectory)buildRequestAndReturnResponse(action);
        }

        public AWGInventoryDirectory searchInventory(InventoryStatus inventoryStatus, int eventId = 0, string dealerNumber = "")
        {
            string action = "ListInventory";
            actionArguments.Add("InventoryStatus", InventoryStatus.Sold.ToString());
            actionArguments.Add("EventId", eventId.ToString());
            actionArguments.Add("DealerNumber", dealerNumber);
            return (AWGInventoryDirectory)buildRequestAndReturnResponse(action);
        }

        private object buildRequestAndReturnResponse(string action)
        {
            var httpRequest = createHttpRequestAndAddHeaders(action);
            var soapAction = buildSoapActionAndAddParameters(action);
            var requestXmlDocument = createRequestXmlDocument(soapAction);
            httpRequest = attachPayloadToRequest(requestXmlDocument, httpRequest);
            return sendRequest(httpRequest).Result;
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

        private async Task<object> sendRequest(HttpRequestMessage httpRequest)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.SendAsync(httpRequest))
                {
                    var soapResponse = await response.Content.ReadAsStringAsync();
                    var parsedResponse = parseSoapResponse(soapResponse);
                    return deserializeResponse(parsedResponse);
                }
            }
        }

        private XElement parseSoapResponse(string response)
        {
            return XElement.Parse(response).Descendants("AWGDataSet").First();
        }

        private object deserializeResponse(XElement parsedResponse)
        {
            var serializer = new XmlSerializer(typeof(AWGEventDirectory));
            var xmlReader = parsedResponse.CreateReader();
            return serializer.Deserialize(xmlReader);
        }
    }

    public enum EventStatus
    {
        AllEvents,
        Upcoming,
        InProgress,
        Ended,
        Cancelled
    }

    public enum InventoryStatus
    {
        AllItems,
        ReadyForRelease,
        InAuction,
        NoSale,
        Sold,
        Cancelled
    }
}
