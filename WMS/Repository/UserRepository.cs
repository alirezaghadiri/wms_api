using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WMS.DB;
using WMS.IRepository;
using WMS.Models;

namespace WMS.Repository
{
    
    public class UserRepository:IUser
    {
        private WMSDBContext contaxt { get; set; }
        public UserRepository()
        {
            contaxt = new WMSDBContext ();
        }

        public bool Add(user _user)
        {
            try
            {
                _user.PasswordSalt = Guid.NewGuid().ToString("N");
                _user.password = utiles.Tools.hashedPassword(_user.password, _user.PasswordSalt);
                contaxt.Users.Add(_user);
                contaxt.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public user Find(int id)
        {
            try
            {
                return contaxt.Users
                .Where(p => p.id == id).FirstOrDefault();
            }
            catch
            {
                return null;
            }
        }

        public ICollection<user> GetAll()
        {
            return contaxt.Users.ToList();
        }

        public bool Update(user _user)
        {
            try
            {
                var _contaxt = contaxt.Users.Where(p => p.id == _user.id).FirstOrDefault();
                _contaxt.username = _user.username;
                _contaxt.id = _user.id;
                _contaxt.First_Name = _user.First_Name;
                _contaxt.Last_Name = _user.Last_Name;
                _contaxt.active=_user.active;
                _contaxt.active=_user.active;
                contaxt.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public user FindByusername(string username)
        {
            try
            {
                return contaxt.Users
                .Where(p => p.username == username).FirstOrDefault();
            }
            catch
            {
                return null;
            }
        }

        public bool changeState(int id)
        {
            try
            {
                var _contaxt = contaxt.Users.First(p => p.id == id);
                _contaxt.active = !_contaxt.active;
                contaxt.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
           


        }
    }
}