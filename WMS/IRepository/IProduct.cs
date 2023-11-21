using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WMS.Models;

namespace WMS.IRepository
{
    public interface IProduct
    {
        bool Add(product _product);
        bool Update(product _product);
        product Find(int id);
        product FindByArtic(string artic);
        bool Delete (int id);
        bool ChangeState(int id);
        ICollection<product> GetAll();
    }
}