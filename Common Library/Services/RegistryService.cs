using Common_Library.Business.Components;
using Common_Library.Business.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Common_Library.Services
{
    public class RegistryService
    {
        Registry registry;

        public RegistryService(string RemoteComputer, string Username, string Password)
        {
            registry = new Registry(RemoteComputer, Username, Password);
        }

        public SortedSet<Software> GetInstalledSoftware()
        {
            return registry.GetInstalledSoftware();
        }

        public async Task<SortedSet<Software>> GetInstalledSoftwareAsync()
        {
            return await Task.Run(() => GetInstalledSoftware());
        }
    }
}
