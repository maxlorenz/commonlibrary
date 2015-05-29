using Common_Library.Business.Components;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace Common_Library.Services
{
    public class FileSystemService
    {
        FileSystem fileSystem = new FileSystem();

        public AuthorizationRuleCollection GetAccessRules(string Path)
        {
            return fileSystem.GetAccessRules(Path);
        }

        public async Task<AuthorizationRuleCollection> GetAccessRulesAsync(string Path)
        {
            return await Task.Run(() => GetAccessRules(Path));
        }
    }
}
