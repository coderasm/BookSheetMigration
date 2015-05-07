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
        private readonly Dictionary<string, string> actionArguments;

        public AWGServiceClient()
        {
            actionArguments = new Dictionary<string, string>();
        }

        public AWGEventDirectory findEventsByStatus(EventStatus eventStatus)
        {
            string action = "ListEvent";
            actionArguments.Add("eventStatus", eventStatus.ToString());
            var response = buildMessageAndReturnResponse(action, actionArguments);
            var deserializer = new Deserializer<AWGEventDirectory>(response);
            return deserializer.deserializeResponse();
        }

        public AWGInventoryDirectory searchInventory(InventoryStatus inventoryStatus, int eventId = 0, string dealerNumber = "")
        {
            string action = "ListInventory";
            actionArguments.Add("InventoryStatus", InventoryStatus.Sold.ToString());
            actionArguments.Add("EventId", eventId.ToString());
            actionArguments.Add("DealerNumber", dealerNumber);
            var response = buildMessageAndReturnResponse(action, actionArguments);
            var deserializer = new Deserializer<AWGInventoryDirectory>(response);
            return deserializer.deserializeResponse();
        }

        private XElement buildMessageAndReturnResponse(string action, Dictionary<string, string> actionArguments)
        {
            var messageBuilder = new SoapRequestMessageBuilder(action, actionArguments);
            var message = messageBuilder.buildSoapRequestMessage();
            return message.sendMessage().Result;
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
