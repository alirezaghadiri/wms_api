using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WMS.DB;
using WMS.IRepository;
using WMS.Models;

namespace WMS.Repository
{
    public class binRepository : IBin
    {
        private WMSDBContext contaxt { get; set; }
        public binRepository()
        {
            contaxt = new WMSDBContext();
        }

        public bool Add(bin _Bin)
        {
            try
            {
                _Bin.CreatedDate = DateTime.Now;
                _Bin.CreatedByUserId = 1;
                contaxt.Bins.Add(_Bin);
                contaxt.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(bin _Bin)
        {
            try
            {
                var _contaxt = contaxt.Bins.Where(p => p.binKey == _Bin.binKey).FirstOrDefault();
                _contaxt.Description = _Bin.Description;
                _contaxt.locationid = _Bin.locationid;
                _contaxt.productid = _Bin.productid;
                _contaxt.isactive = _Bin.isactive;
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

        public bin Find(int id)
        {
            try
            {
                return contaxt.Bins
                .Where(p => p.binKey == id).FirstOrDefault();
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
                var _contaxt = contaxt.Bins.Where(p => p.binKey == id).FirstOrDefault();
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

        public bool ChangeState(int id)
        {
            try
            {
                var _contaxt = contaxt.Bins.Where(p => p.binKey == id).FirstOrDefault();
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

        public ICollection<bin> GetAll()
        {
            return contaxt.Bins.ToList();
        }









    }
}