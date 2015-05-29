using Common_Library.Data.Access.Filesystem;
using System.Security.AccessControl;

namespace Common_Library.Business.Components
{
    class FileSystem
    {
        AccessControl control = new AccessControl();

        public AuthorizationRuleCollection GetAccessRules(string Path)
        {
            return control.GetAccessRules(Path);
        }
    }
}
