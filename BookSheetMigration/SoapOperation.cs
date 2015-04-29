using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookSheetMigration
{
    public class SoapOperation
    {
        public string operation { get; private set; }
        private Dictionary<string, string> soapPairs;

        public SoapOperation(string operation)
        {
            this.operation = operation;
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
