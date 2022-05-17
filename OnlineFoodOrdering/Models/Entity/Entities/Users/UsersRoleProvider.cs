using OnlineFoodOrdering.Models.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace OnlineFoodOrdering.Models
{
    public class UsersRoleProvider : RoleProvider
    {
        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                var userRoles = (from userAccounts in context.UserAccounts
                                 join roleMapping in context.UserRolesMappings
                                 on userAccounts.Id equals roleMapping.userID
                                 join role in context.RoleMasters
                                 on roleMapping.roleID equals role.ID
                                 where userAccounts.UserName == username
                                 select role.RollName).ToArray();
                return userRoles;
            }
            //throw new NotImplementedException();
        }

        public int GetRoleIdForUser(string username)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                var userRoleId = (from userAccount in context.UserAccounts
                                 join roleMapping in context.UserRolesMappings
                                 on userAccount.Id equals roleMapping.userID
                                 join role in context.RoleMasters
                                 on roleMapping.roleID equals role.ID
                                 where userAccount.UserName == username
                                 select role.ID).FirstOrDefault();
                return userRoleId;
            }
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}