using System.Collections.Generic;
using System.Linq;
using System.Web.Security;

namespace DL.Core.Web.Security
{
    public sealed class RolesProviderFacade
    {
        public void AddRole(string roleToAdd)
        {
            if (!Roles.RoleExists(roleToAdd))
            {
                Roles.CreateRole(roleToAdd);
            }
        }

        public void AddUsersToRole(IEnumerable<string> userNames, string roleName)
        {
            Roles.AddUsersToRole(userNames.ToArray(), roleName);
        }

        public void AddUsersToRoles(IEnumerable<string> userNames, IEnumerable<string> roleNames)
        {
            Roles.AddUsersToRoles(userNames.ToArray(), roleNames.ToArray());
        }

        public void AddUserToRole(string userName, string roleName)
        {
            Roles.AddUserToRole(userName, roleName);
        }

        public void AddUserToRoles(string userName, IEnumerable<string> roleNames)
        {
            Roles.AddUserToRoles(userName, roleNames.ToArray());
        }

        public void DeleteRole(string roleToDelete)
        {
            if (Roles.RoleExists(roleToDelete)
                && Roles.GetUsersInRole(roleToDelete).Length == 0)
            {
                Roles.DeleteRole(roleToDelete);
            }
        }

        public IEnumerable<string> FindUsersInRole(string roleName, string userNameToMatch)
        {
            return Roles.FindUsersInRole(roleName, userNameToMatch).ToList();
        }

        public bool IsUserInRole(string userName, string roleName)
        {
            return Roles.IsUserInRole(userName, roleName);
        }

        public IEnumerable<string> GetAllRoles()
        {
            return Roles.GetAllRoles().ToList();
        }

        public IEnumerable<string> GetRolesForUser(string userName)
        {
            return Roles.GetRolesForUser(userName).ToList();
        }

        public IEnumerable<string> GetUsersInRole(string roleName)
        {
            return Roles.GetUsersInRole(roleName).ToList();
        }

        public void RemoveUserFromRole(string userName, string roleName)
        {
            Roles.RemoveUserFromRole(userName, roleName);            
        }

        public void RemoveUserFromRoles(string userName, IEnumerable<string> roleNames)
        {
            Roles.RemoveUserFromRoles(userName, roleNames.ToArray());   
        }

        public void RemoveUsersFromRole(IEnumerable<string> userNames, string roleName)
        {
            Roles.RemoveUsersFromRole(userNames.ToArray(), roleName);
        }

        public void RemoveUsersFromRoles(IEnumerable<string> userNames, IEnumerable<string> roleNames)
        {
            Roles.RemoveUsersFromRoles(userNames.ToArray(), roleNames.ToArray());
        }

        public bool RoleExists(string roleName)
        {
            return Roles.RoleExists(roleName);
        }
    }
}