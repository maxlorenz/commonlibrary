using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;

namespace Common_Library.Data.Access.LDAP
{
    class Groups
    {

        public List<Principal> allGroups(Principal parent)
        {
            var results = new List<Principal>();

            foreach (var group in parent.GetGroups())
            {
                results.Add(group);
                results.AddRange(allGroups(group));
            }

            return results;
        }
    }
}
