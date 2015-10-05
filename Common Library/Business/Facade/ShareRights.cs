using Common_Library.Business.Components;
using Common_Library.Business.Entities;
using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Security.AccessControl;

namespace Common_Library.Business.Facade
{
    class ShareRights
    {
        LDAP ldap;
        FileSystem fileSystem;

        public ShareRights(string Domain)
        {
            ldap = new LDAP(Domain);
            fileSystem = new FileSystem();
        }

        private PrincipalSearchResult<Principal> GetAllUsersOfAccessRule(FileSystemAccessRule rule)
        {
            var group = ldap.GetFromAccessRule(rule);

            // GetMembers(true) finds all members recursive
            return (group as GroupPrincipal).GetMembers(true);
        }

        private Entities.DirectoryAccessRule GetRule(FileSystemAccessRule rule, UserPrincipal user)
        {
            return new Entities.DirectoryAccessRule()
            {
                Access = rule.AccessControlType == AccessControlType.Allow ? Access.Allow : Access.Deny,
                Right = rule.FileSystemRights.ToString(),
                UserName = user.Name,
                SAM = user.SamAccountName,
                LastLogon = user.LastLogon ?? new DateTime(),
                Enabled = user.Enabled ?? false
            };
        }

        public IEnumerable<Entities.DirectoryAccessRule> GetDirectoryAccessRules(string Directory)
        {
            foreach (FileSystemAccessRule rule in fileSystem.GetAccessRules(Directory))
            {
                foreach (Principal principal in GetAllUsersOfAccessRule(rule))
                {
                    if (principal is UserPrincipal)
                    {
                        yield return GetRule(rule, (UserPrincipal)principal);
                    }
                }
            }
        }
    }
}
