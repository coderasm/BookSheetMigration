using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Security;
using System.Text;

namespace BookSheetMigration
{
    public class AWGServiceCredential
    {
        public string securityToken { get; private set; }
        public string userName { get; private set; }
        public string password { get; private set; }

        public AWGServiceCredential(string securityToken, string userName, string password)
        {
            this.securityToken = securityToken;
            this.userName = userName;
            this.password = password;
        }
    }
}
