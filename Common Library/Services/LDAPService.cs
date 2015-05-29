using Common_Library.Business.Components;
using System.Collections.Generic;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace Common_Library.Services
{
    public class LDAPService
    {
        LDAP ldap;

        public LDAPService(string Domain)
        {
            ldap = new LDAP(Domain);
        }

        public IEnumerable<Principal> FindAllByName(string Name)
        {
            return ldap.FindAllByName(Name);
        }

        public async Task<Principal> FindOneByNameAsync(string Name)
        {
            return await Task.Run(() => FindOneByName(Name));
        }

        public Principal FindOneByName(string Name)
        {
            return ldap.FindOneByName(Name);
        }

        public async Task<IEnumerable<Principal>> FindAllByNameAsync(string Name)
        {
            return await Task.Run(() => FindAllByName(Name));
        }

        public PropertyCollection GetPropertyCollection(UserPrincipal User)
        {
            return ldap.GetADPropertyCollection(User);
        }

        public async Task<PropertyCollection> GetPropertyCollectionAsync(UserPrincipal User)
        {
            return await Task.Run(() => GetPropertyCollection(User));
        }

        public Principal GetFromAccessRule(AccessRule Rule)
        {
            return ldap.GetFromAccessRule(Rule);
        }

        public bool IsInheritedMemberOf(Principal Member, GroupPrincipal Group)
        {
            return ldap.InheritedMemberOf(Member, Group);
        }

        public async Task<bool> IsInheritedMemberOfAsync(Principal Member, GroupPrincipal Group)
        {
            return await Task.Run(() => IsInheritedMemberOf(Member, Group));
        }
    }
}
