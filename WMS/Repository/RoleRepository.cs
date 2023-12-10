using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WMS.DB;
using WMS.IRepository;
using WMS.Models;

namespace WMS.Repository
{
    
    public class RoleRepository:IRole
    {
        private WMSDBContext contaxt { get; set; }
        public RoleRepository()
        {
            contaxt = new WMSDBContext ();
        }

        public bool Add(Role _Role)
        {
            try
            {
                contaxt.Roles.Add(_Role);
                contaxt.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Role Find(int id)
        {
            try
            {
                return contaxt.Roles
                .Where(p => p.RoleId == id).FirstOrDefault();
            }
            catch
            {
                return null;
            }
        }

        public ICollection<Role> GetAll()
        {
            return contaxt.Roles.ToList();
        }

        public bool Update(Role _Role)
        {
            try
            {
                var _contaxt = contaxt.Roles.Where(p => p.RoleId == _Role.RoleId).FirstOrDefault();
                _contaxt.Title = _Role.Title;
                _contaxt.Description = _Role.Description;
                contaxt.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Role FindByName(string name)
        {
            try
            {
                return contaxt.Roles
                .Where(p => p.Title == name).FirstOrDefault();
            }
            catch
            {
                return null;
            }
        }
    }
}