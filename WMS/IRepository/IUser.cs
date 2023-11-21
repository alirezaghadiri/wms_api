using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WMS.Models;

namespace WMS.IRepository
{
    public interface IUser
    {
        bool Add(user _user);
        bool Update(user _user);
        user Find(int id);
        user FindByusername(string username);
        bool changeState(int id);
        ICollection<user> GetAll();
        
    }
}