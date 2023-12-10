using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WMS.Models;

namespace WMS.IRepository
{
    public interface IRole
    {
        bool Add(Role _user);
        bool Update(Role _user);
        Role Find(int id);
        Role FindByName(string name);
        ICollection<Role> GetAll();


    }
}