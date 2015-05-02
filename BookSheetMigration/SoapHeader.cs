using System.Collections.Generic;

namespace BookSheetMigration
{
    public class SoapHeader
    {
        private Dictionary<string, string> soapHeaderPairs;

        public SoapHeader()
        {
            soapHeaderPairs = new Dictionary<string, string>();
        }

        public void addPairToHeader(string key, string value)
        {
            soapHeaderPairs.Add(key, value);
        }

        public int getPairCount()
        {
            return soapHeaderPairs.Count;
        }
    }
}
