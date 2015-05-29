using Common_Library.Data.Access.LDAP;
using System.Collections.Generic;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Security.AccessControl;

namespace Common_Library.Business.Components
{
    class LDAP
    {
        ObjectFinder finder;
        Groups groups = new Groups();

        public LDAP(string Domain)
        {
            finder = new ObjectFinder(Domain);
        }

        public IEnumerable<Principal> FindAllByName(string Name)
        {
            var user = finder.GetEmptyUser();
            user.Name = Name;

            return finder.FindAll(user);
        }

        public Principal FindOneByName(string Name)
        {
            var user = finder.GetEmptyUser();
            user.Name = Name;

            return finder.FindOne(user);
        }

        public bool InheritedMemberOf(Principal principal, GroupPrincipal group)
        {
            var allGroups = groups.allGroups(principal);

            foreach (GroupPrincipal inheritedGroup in allGroups)
                if (inheritedGroup.IsMemberOf(group)) 
                    return true;

            return false;
        }

        public Principal GetFromAccessRule(AccessRule Rule)
        {
            return finder.GetFromIdentity(Rule.IdentityReference);
        }

        public PropertyCollection GetADPropertyCollection(UserPrincipal User)
        {
            return finder.GetADEntry(User).Properties;
        }
    }
}
