using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WMS.Models;

namespace WMS.IRepository
{
    public interface IIOProduct
    {
        bool Add(IOProduct _IOProduct);
        bool Update(IOProduct _IOProduct);
        bool changeLocation(int id, int newLocationid);
        bool Delete (int id);
        ICollection<IOProduct> GetAll();
    }
}