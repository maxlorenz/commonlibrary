using Common_Library.Business.Entities;
using Common_Library.Business.Facade;
using System.Collections.Generic;

namespace Common_Library.Services
{
    public class SharerightsService
    {
        ShareRights rights;

        public SharerightsService(string Domain)
        {
            rights = new ShareRights(Domain);
        }

        public IEnumerable<DirectoryAccessRule> GetDirectoryAccessRules(string Directory)
        {
            return rights.GetDirectoryAccessRules(Directory);
        }
    }
}
