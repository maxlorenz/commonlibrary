using Common_Library.Business.Components;
using Common_Library.Business.Entities;
using System.Collections.Generic;

namespace Common_Library.Business.Facade
{
    class InstalledSoftware
    {
        static string softwareRegLoc = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\";
        static string softwareRegLoc64 = @"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall";

        Registry registry;
        WMI wmi;

        public InstalledSoftware(string RemoteComputer)
        {
            registry = new Registry(RemoteComputer);
            wmi = new WMI(RemoteComputer);
        }

        public InstalledSoftware(string RemoteComputer, string Username, string Password)
        {
            registry = new Registry(RemoteComputer, Username, Password);
            wmi = new WMI(RemoteComputer, Username, Password);
        }

        public SortedSet<Software> GetInstalledSoftware()
        {
            var software = new SortedSet<Software>();
            
            software.UnionWith(getSoftwareFromRegistry(softwareRegLoc));
            software.UnionWith(getSoftwareFromRegistry(softwareRegLoc64));

            software.UnionWith(getSoftwareFromWMI());

            return software;
        }

        private SortedSet<Software> getSoftwareFromWMI() 
        {
            var software = new SortedSet<Software>();
            var wmiSoftware = wmi.GetWQLResults("SELECT Name, Version from Win32_Product");

            foreach (var entry in wmiSoftware) 
            {
                var temp = new Software();

                foreach (var keyValuePair in entry) 
                {
                    if (keyValuePair.Key == "Name") temp.Name = keyValuePair.Value;
                    if (keyValuePair.Key == "Version") temp.Version = keyValuePair.Value;
                }

                software.Add(temp);
            }

            return software;
        }

        private SortedSet<Software> getSoftwareFromRegistry(string regLoc)
        {
            var set = new SortedSet<Software>();

            foreach (var subKeyName in registry.GetSubKeys(regLoc))
            {
                Software temp = new Software();

                temp.Name = registry.GetRegValues("DisplayName", regLoc, subKeyName);
                temp.Version = registry.GetRegValues("DisplayVersion", regLoc, subKeyName);

                if (!string.IsNullOrEmpty(temp.Name))
                    set.Add(temp);
            }

            return set;

        }
    }
}
