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

        public AWGInventoryDirectory findVehiclesByStatusAndId(InventoryStatus inventoryStatus, int eventId = 0, string dealerNumber = "")
        {
            ListInventoryOperation listInventoryOperation = new ListInventoryOperation(InventoryStatus.Sold, eventId, dealerNumber);
            return listInventoryOperation.execute();
        }

        public AWGTransactionDirectory findTransactionsByStatusAndId(TransactionStatus transactionStatus, int eventId = 0, string sellingDealerNumber = "", string buyingDealerNumber = "")
        {
            ListTransactionOperation listTransactionOperation = new ListTransactionOperation(TransactionStatus.New, eventId, sellingDealerNumber, buyingDealerNumber);
            return listTransactionOperation.execute();
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

    public enum TransactionStatus
    {
        AllTransactions,
        New,
        InProgress,
        Cancelled,
        Complete,
        IfSale,
        InAbitration
    }
}
