using System.Management;

namespace Common_Library.Data.Access.Registry
{
    class WMIRegistry
    {
        ManagementClass registry;

        public WMIRegistry(string remoteComputer, string userName, string password)
        {
            var path = string.Format(@"\\{0}\root\cimv2", remoteComputer);
            var connection = new ConnectionOptions() { Username = userName, Password = password };
            var scope = new ManagementScope(path, connection);
            var wmiClass = new ManagementPath("StdRegProv");

            registry = new ManagementClass(scope, wmiClass, null);
        }

        public ManagementClass GetRegistryClass()
        {
            return registry;
        }

    }
}
