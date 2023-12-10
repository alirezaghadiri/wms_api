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
        bool changeLocation(Guid id, int newLocationid);
        bool Delete (Guid id);
        ICollection<IOProduct> GetAll();
    }
}