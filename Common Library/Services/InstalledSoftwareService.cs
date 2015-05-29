using Common_Library.Business.Entities;
using Common_Library.Business.Facade;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Common_Library.Services
{
    public class InstalledSoftwareService
    {
        InstalledSoftware installedSoftware;

        public InstalledSoftwareService(string RemoteComputer, string Username, string Password)
        {
            installedSoftware = new InstalledSoftware(RemoteComputer, Username, Password);
        }

        public SortedSet<Software> GetInstalledSoftware()
        {
            return installedSoftware.GetInstalledSoftware();
        }

        public async Task<SortedSet<Software>> GetInstalledSoftwareAsync()
        {
            return await Task.Run(() => GetInstalledSoftware());
        }
    }
}
