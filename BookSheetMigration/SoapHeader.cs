using System.Collections.Generic;

namespace BookSheetMigration
{
    public class SoapHeader
    {
        private Dictionary<string, string> soapHeaderPairs;

        public SoapHeader()
        {
            soapHeaderPairs = new Dictionary<string, string>();
            setDefaultContentType();
        }

        private void setDefaultContentType()
        {
            soapHeaderPairs.Add("Content-Type", "text/xml; charset=utf-8");
        }

        public void addPairToHeader(string key, string value)
        {
            soapHeaderPairs.Add(key, value);
        }

        public object getPairCount()
        {
            return soapHeaderPairs.Count;
        }
    }
}
