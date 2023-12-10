using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using WMS.DB;

namespace WMS.Auth
{
    public class EspiarRoleProvider : RoleProvider
    {
        IRepository.IRole  RoleRepo;
        IRepository.IUser UserRepo;
        private WMSDBContext contaxt { get; set; }
        public EspiarRoleProvider()
        {
            RoleRepo = new Repository.RoleRepository();
            UserRepo= new Repository.UserRepository();
            contaxt = new WMSDBContext();
        }

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
            return RoleRepo.GetAll().Select(R=>R.Title).ToArray();
        }

        public override string[] GetRolesForUser(string username)
        {
            var user=UserRepo.FindByusername(username);
            return user.Roles.Select(R=>R.Title).ToArray();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            return RoleRepo.FindByName(roleName).Users.Select(p=>p.username).ToArray();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            return (RoleRepo.FindByName(roleName).Users.Where(u => u.username == username).Count() == 1);
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
           return (RoleRepo.FindByName(roleName) is null) ? false : true;
        }
    }
}