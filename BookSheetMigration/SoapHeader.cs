using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public object getPairCount()
        {
            return soapHeaderPairs.Count;
        }
    }
}
