using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.XPath;

namespace BookSheetMigration
{
    public abstract class SoapOperation<T>
    {
        protected readonly Dictionary<string, string> actionArguments = new Dictionary<string, string>();
        protected string action = "";
        protected string pathToDataNodeFromRoot = "/*";

        public T execute()
        {
            var response = buildMessageAndReturnResponse(action, actionArguments);
            var extractedData = extractDataNode(response);
            var deserializer = new Deserializer<T>(extractedData);
            return deserializer.deserializeResponse();
        }

        private XElement buildMessageAndReturnResponse(string action, Dictionary<string, string> actionArguments)
        {
            var messageBuilder = new SoapRequestMessageBuilder(action, actionArguments);
            var message = messageBuilder.buildSoapRequestMessage();
            return message.sendMessage().Result;
        }

        protected abstract void setPathToDataNodeFromRoot();

        protected XElement extractDataNode(XElement response)
        {
            setPathToDataNodeFromRoot();
            return response.XPathSelectElement(pathToDataNodeFromRoot);
        }
    }
}
