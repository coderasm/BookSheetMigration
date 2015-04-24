using System.ServiceModel;
using System.ServiceModel.Channels;
using BookSheetMigration.AWGService;

namespace BookSheetMigration
{
    public class AWGServiceClientFactory
    {

        private readonly string awgSoapUrl = "http://abssandbox.autoremarketers.com/webapp/webservices/dataadapter.asmx";

        public AWGServiceClient createClient()
        {
            return new AWGServiceClient(createDataAdapterSoapClient());
        }

        private DataAdapterSoapClient createDataAdapterSoapClient()
        {
            return new DataAdapterSoapClient(createBinding(), createEndpointAddress());
        }

        private Binding createBinding()
        {
            return new BasicHttpBinding();
        }

        private EndpointAddress createEndpointAddress()
        {
            return new EndpointAddress(awgSoapUrl);
        }
    }
}
