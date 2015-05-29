using Common_Library.Data.Access.Registry;
using System.Management;

namespace Common_Library.Business.Components
{
    class Registry
    {
        public static uint HKEY_LOCAL_MACHINE = 0x80000002;
        ManagementClass wmiRegistry;

        public Registry(string RemoteComputer, string Username, string Password) 
        {
            var registry = new WMIRegistry(RemoteComputer, Username, Password);
            wmiRegistry = registry.GetRegistryClass();
        }

        public string[] GetSubKeys(string registryPath)
        {
            var method = wmiRegistry.GetMethodParameters("EnumKey");

            method["hDefkey"] = HKEY_LOCAL_MACHINE;
            method["sSubKeyName"] = registryPath;

            var entries = wmiRegistry.InvokeMethod("EnumKey", method, null);

            return entries["sNames"] as string[];
        }

        public string GetRegValues(string name, string registryPath, string subKeyName)
        {
            var method = wmiRegistry.GetMethodParameters("GetStringValue");

            method["sSubKeyName"] = registryPath + @"\" + subKeyName;
            method["sValueName"] = name;

            var value = wmiRegistry.InvokeMethod("GetStringValue", method, null);
            var result = value.Properties["sValue"].Value;

            if (result != null)
                return result.ToString();
            else
                return string.Empty;
        }
    }
}
