using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BookSheetMigration
{
    public abstract class SoapOperation<T>
    {
        protected readonly Dictionary<string, string> actionArguments = new Dictionary<string, string>();
        protected string action = "";

        protected SoapOperation() { }

        public T execute()
        {
            var response = buildMessageAndReturnResponse(action, actionArguments);
            var deserializer = new Deserializer<T>(response);
            return deserializer.deserializeResponse();
        }

        private XElement buildMessageAndReturnResponse(string action, Dictionary<string, string> actionArguments)
        {
            var messageBuilder = new SoapRequestMessageBuilder(action, actionArguments);
            var message = messageBuilder.buildSoapRequestMessage();
            return message.sendMessage().Result;
        }
    }
}
