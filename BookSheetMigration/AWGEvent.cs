using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace BookSheetMigration
{
    public class AWGEvent
    {
        [XmlElement("EventId")]
        public int eventId;

        [XmlElement("StartTime")]
        public DateTime startTime;

        [XmlElement("EndTime")]
        public DateTime endTime;
    }
}
