using System.IO;
using System.Security.AccessControl;
using System.Security.Principal;

namespace Common_Library.Data.Access.Filesystem
{
    class AccessControl
    {
        public AuthorizationRuleCollection GetAccessRules(string Path)
        {
            var access = Directory.GetAccessControl(Path);

            return access.GetAccessRules(true, true, typeof(SecurityIdentifier));
        }
    }
}
