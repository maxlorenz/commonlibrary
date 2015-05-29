using System.Collections.Generic;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Security.Principal;

namespace Common_Library.Data.Access.LDAP
{
    class ObjectFinder
    {
        public PrincipalContext ActiveDirectory;

        public ObjectFinder(string Domain)
        {
            ActiveDirectory = new PrincipalContext(ContextType.Domain, Domain);
        }

        public UserPrincipal GetEmptyUser()
        {
            return new UserPrincipal(ActiveDirectory);
        }

        public DirectoryEntry GetADEntry(UserPrincipal User)
        {
            return (DirectoryEntry)User.GetUnderlyingObject();
        }

        public IEnumerable<Principal> FindAll(UserPrincipal user)
        {
            var search = new PrincipalSearcher(user);

            foreach (var result in search.FindAll())
                yield return result;
        }

        public Principal FindOne(UserPrincipal user)
        {
            var search = new PrincipalSearcher(user);

            return search.FindOne();
        }

        public Principal GetFromIdentity(IdentityReference reference)
        {
            return Principal.FindByIdentity(ActiveDirectory, reference.Value);
        }
    }
}