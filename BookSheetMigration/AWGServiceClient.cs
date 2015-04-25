using System.Data;
using BookSheetMigration.AWGService;

namespace BookSheetMigration
{
    public class AWGServiceClient
    {
        private AWGServiceCredential credentials;
        private AWGService.DataAdapterSoapClient dataAdapterSoapClient;

        public AWGServiceClient(DataAdapterSoapClient dataAdapterSoapClient)
        {
            this.dataAdapterSoapClient = dataAdapterSoapClient;
        }

        public void applyCredentials(AWGServiceCredential credentials)
        {
            this.credentials = credentials;
        }

        public bool areCredentialsApplied()
        {
            return credentials != null;
        }

        public DataSet findEventsByStatus(EventStatus eventStatus)
        {
            var results = dataAdapterSoapClient.ListEvent(credentials.securityToken, credentials.userName, credentials.password,
                eventStatus).DataSet;
            return results;
        }
    }
}
