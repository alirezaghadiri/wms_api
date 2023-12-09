using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WMS.Models;

namespace WMS.IRepository
{
    public interface ILocation
    {

        bool Add(Location _Bin);
        bool Update(Location _Bin);
        Location Find(int id);
        Location FindByLocation(int line, int row, int column);
        bool Delete (int id);
        bool changeActice(int id);
        bool ChangeState(int id, int state);
        bool IsEmpty(int Locationid);
        ICollection<Location> GetAll();
    }
}