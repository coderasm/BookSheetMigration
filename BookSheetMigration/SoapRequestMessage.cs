using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BookSheetMigration
{
    public class SoapRequestMessage
    {
        private HttpRequestMessage soapRequestMessage;

        public SoapRequestMessage(HttpRequestMessage soapRequestMessage)
        {
            this.soapRequestMessage = soapRequestMessage;
        }

        public async Task<XElement> sendMessage()
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.SendAsync(soapRequestMessage))
                {
                    var soapResponse = await response.Content.ReadAsStringAsync();
                    return parseSoapResponse(soapResponse);
                }
            }
        }

        private XElement parseSoapResponse(string response)
        {
            return XElement.Parse(response).Descendants("AWGDataSet").First();
        }
    }
}
