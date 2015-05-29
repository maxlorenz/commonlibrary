using Common_Library.Business.Entities;
using Common_Library.Data.Access.Registry;
using System.Collections.Generic;

namespace Common_Library.Business.Components
{
    class Registry
    {
        static string softwareRegLoc = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\";
        static string softwareRegLoc64 = @"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall";

        WMIRegistry registry;

        public Registry(string RemoteComputer, string Username, string Password)
        {
            this.registry = new WMIRegistry(RemoteComputer, Username, Password);
        }

        public SortedSet<Software> GetInstalledSoftware()
        {
            var software = getSoftwareFromKey(softwareRegLoc);
            var software64 = getSoftwareFromKey(softwareRegLoc64);

            software.UnionWith(software64);

            return software;
        }

        private SortedSet<Software> getSoftwareFromKey(string regLoc)
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
