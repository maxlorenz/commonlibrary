using System.Collections.Generic;
using System.Management;

namespace Common_Library.Data.Access.WMI
{
    class WQL
    {
        private ManagementScope scope = new ManagementScope();
        
        public IEnumerable<PropertyDataCollection> ExecuteQuery(string Query)
        {
            var query = new WqlObjectQuery(Query);
            var searcher = new ManagementObjectSearcher(scope, query);

            foreach (var result in searcher.Get())
                yield return result.Properties;
        }

        public void SetCredentials(string Username, string Password)
        {
            scope.Options = new ConnectionOptions() { Username = Username, Password = Password };
        }

        public void SetRemoteComputer(string Computername)
        {
            var path = string.Format(@"\\{0}\root\cimv2", Computername);
            scope.Path = new ManagementPath(path);
        }
    }
}
