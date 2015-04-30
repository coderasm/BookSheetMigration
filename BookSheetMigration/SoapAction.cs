using System.Collections.Generic;

namespace BookSheetMigration
{
    public class SoapAction
    {
        public string action { get; private set; }
        public string xmlnamespace { get; private set; }
        public Dictionary<string, string> soapPairs { get; private set; }

        public SoapAction(string action, string xmlnamespace)
        {
            this.action = action;
            this.xmlnamespace = xmlnamespace;
            soapPairs = new Dictionary<string, string>();
        }

        public int getPairCount()
        {
            return soapPairs.Count;
        }

        public void addPairToOperation(string key, string value)
        {
            soapPairs.Add(key, value);
        }
    }
}
