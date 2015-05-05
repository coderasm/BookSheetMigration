using System.Collections.Generic;

namespace BookSheetMigration
{
    public class SoapOperation
    {
        public string Operation { get; private set; }
        public string xmlnamespace { get; private set; }
        public Dictionary<string, string> parameters { get; private set; }

        public SoapOperation(string operation, string xmlnamespace)
        {
            this.Operation = operation;
            this.xmlnamespace = xmlnamespace;
            parameters = new Dictionary<string, string>();
        }

        public int getPairCount()
        {
            return parameters.Count;
        }

        public void addPairToAction(string key, string value)
        {
            parameters.Add(key, value);
        }
    }
}
