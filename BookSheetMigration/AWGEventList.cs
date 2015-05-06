using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace BookSheetMigration
{
    [Serializable, XmlRoot("AWGDataSet")]
    public class AWGEventList
    {
        [XmlElement("Event")]
        public List<AWGEvent> awgEvents = new List<AWGEvent>();
    }
}
