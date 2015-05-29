using System.Management;

namespace Common_Library.Data.Access.Registry
{
    class WMIRegistry
    {
        public static uint HKEY_LOCAL_MACHINE = 0x80000002;
        ManagementClass registry;

        public WMIRegistry(string remoteComputer, string userName, string password)
        {
            var path = string.Format(@"\\{0}\root\cimv2", remoteComputer);
            var connection = new ConnectionOptions() { Username = userName, Password = password };
            var scope = new ManagementScope(path, connection);
            var wmiClass = new ManagementPath("StdRegProv");

            registry = new ManagementClass(scope, wmiClass, null);
        }

        public string[] GetSubKeys(string registryPath)
        {
            var method = registry.GetMethodParameters("EnumKey");

            method["hDefkey"] = HKEY_LOCAL_MACHINE;
            method["sSubKeyName"] = registryPath;

            var entries = registry.InvokeMethod("EnumKey", method, null);

            return entries["sNames"] as string[];
        }

        public string GetRegValues(string name, string registryPath, string subKeyName)
        {
            var method = registry.GetMethodParameters("GetStringValue");

            method["sSubKeyName"] = registryPath + @"\" + subKeyName;
            method["sValueName"] = name;

            var value = registry.InvokeMethod("GetStringValue", method, null);
            var result = value.Properties["sValue"].Value;

            if (result != null)
                return result.ToString();
            else
                return string.Empty;
        }
    }
}
