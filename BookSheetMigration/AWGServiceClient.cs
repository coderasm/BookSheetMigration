using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using BookSheetMigration.AWGService;

namespace BookSheetMigration
{
    public class AWGServiceClient
    {
        private bool isClientAuthenticated = false;
        private AWGServiceCredential credentials;
        private AWGService.DataAdapterSoapClient dataAdapterSoapClient;

        public AWGServiceClient(DataAdapterSoapClient dataAdapterSoapClient)
        {
            this.dataAdapterSoapClient = dataAdapterSoapClient;
        }

        public void authenticate()
        {
            this.isClientAuthenticated = true;
        }

        public bool isAuthenticated()
        {
            return isClientAuthenticated;
        }

        public void applyCredentials(AWGServiceCredential credentials)
        {
            this.credentials = credentials;
        }

        public bool areCredentialsApplied()
        {
            return credentials != null;
        }

        public List<EventDTO> findEventsByStatus(AWGService.EventStatus eventStatus)
        {
            return new List<EventDTO>() {new EventDTO()};
        }
    }
}
