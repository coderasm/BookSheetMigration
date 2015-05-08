using System;
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
        public AWGEventDirectory findEventsByStatus(EventStatus eventStatus)
        {
            ListEventOperation listEventOperation = new ListEventOperation(eventStatus);
            return listEventOperation.execute();
        }

        public AWGInventoryDirectory searchInventory(InventoryStatus inventoryStatus, int eventId = 0, string dealerNumber = "")
        {
            ListInventoryOperation listInventoryOperation = new ListInventoryOperation(InventoryStatus.Sold, eventId, dealerNumber);
            return listInventoryOperation.execute();
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
