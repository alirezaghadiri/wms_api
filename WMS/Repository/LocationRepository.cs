using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WMS.DB;
using WMS.IRepository;
using WMS.Models;

namespace WMS.Repository
{
    public class LocationRepository : ILocation
    {
        private WMSDBContext contaxt { get; set; }
        public LocationRepository()
        {
            contaxt = new WMSDBContext();
        }

        public bool Add(Location _location)
        {
            try
            {
                if (FindByLocation(_location.line, _location.Row, _location.column) == null)
                {
                    _location.CreatedDate = DateTime.Now;
                    _location.CreatedByUserId = 1;
                    contaxt.locations.Add(_location);
                    contaxt.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
               
               
            }
            catch
            {
                return false;
            }
        }

        public bool Update(Location _location)
        {
            try
            {
                var _contaxt = contaxt.locations.Where(p => p.id == _location.id).FirstOrDefault();
                _contaxt.Description = _location.Description;
                _contaxt.line = _location.line;
                _contaxt.Row = _location.Row;
                _contaxt.column = _location.column;
                _contaxt.isactive = _location.isactive;
                _contaxt.State = _location.State;
                _contaxt.ChangedDate = DateTime.Now;
                _contaxt.ChangedByUserId = 1;
                contaxt.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Location Find(int id)
        {
            try
            {
                return contaxt.locations.Where(p => p.id == id).FirstOrDefault();
            }
            catch
            {
                return null;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var _contaxt = contaxt.locations.Where(p => p.id == id).FirstOrDefault();
                _contaxt.Deleted = true;
                _contaxt.DeletedByUserId = 1;
                _contaxt.DeletedDate = DateTime.Now;
                contaxt.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /*
            * state
            * 0: empty
            * 1:Reservation
            * 2:full
        */
        public bool ChangeState(int id, int state)
        {
            try
            {
                var _contaxt = contaxt.locations.Where(p => p.id == id).FirstOrDefault();
                _contaxt.State = state;
                _contaxt.ChangedDate = DateTime.Now;
                _contaxt.ChangedByUserId = 1;
                contaxt.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public ICollection<Location> GetAll()
        {
            return contaxt.locations.Where(p=>p.Deleted==false) .ToList();
        }

        public bool changeActice(int id)
        {
            try
            {
                var _contaxt = contaxt.locations.Where(p => p.id == id).FirstOrDefault();
                _contaxt.isactive = !_contaxt.isactive;
                _contaxt.ChangedDate = DateTime.Now;
                _contaxt.ChangedByUserId = 1;
                contaxt.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool IsEmpty(int Locationid)
        {
            try
            {
                var _contaxt = contaxt.locations.Where(p => p.id == Locationid && p.Deleted==false  && p.isactive==true).FirstOrDefault();
                if (null == _contaxt)
                    return false;
                if (_contaxt.State == 0)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

        public Location FindByLocation(int line, int row, int column)
        {
            try
            {
                return contaxt.locations.Where(p => p.line == line && p.Row == row && p.column == column).First();
            }
            catch
            {
                return null;
            }
           
        }
    }
}