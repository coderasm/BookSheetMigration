using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSheetMigration
{
    class ListEventOperation : SoapOperation<AWGEventDirectory>
    {
        public ListEventOperation(EventStatus eventStatus)
        {
            action = "ListEvent";
            actionArguments.Add("eventStatus", eventStatus.ToString());
        }
    }
}
