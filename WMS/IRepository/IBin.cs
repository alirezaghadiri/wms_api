using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WMS.Models;

namespace WMS.IRepository
{
    public interface IBin
    {
        bool Add(bin _Bin);
        bool Update(bin _Bin);
        bin Find(int id);
        bool Delete (int id);
        bool ChangeState(int id);
        ICollection<bin> GetAll();
    }
}