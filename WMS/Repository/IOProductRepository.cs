using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WMS.DB;
using WMS.IRepository;
using WMS.Models;

namespace WMS.Repository
{
    public class IOProductRepository :IIOProduct
    {
        private WMSDBContext contaxt { get; set; }
        public IOProductRepository()
        {
            contaxt = new WMSDBContext();
        }

        public bool Add(IOProduct _IOProduct)
        {
            try
            {
                _IOProduct.CreatedDate = DateTime.Now;
                _IOProduct.CreatedByUserId = 1;
                contaxt.IOProducts.Add(_IOProduct);
                contaxt.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(IOProduct _IOProduct)
        {
            try
            {
                var _contaxt = contaxt.IOProducts.Where(p => p.id == _IOProduct.id).FirstOrDefault();
                _contaxt.Inputdate = _IOProduct.Inputdate;
                _contaxt.productId = _IOProduct.productId;
                _contaxt.locationid = _IOProduct.locationid;
                _contaxt.Description = _IOProduct.Description;
                _contaxt.flag = _IOProduct.flag;
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

        public bool changeLocation(Guid id, int newLocationid)
        {
            try
            {
                var _contaxt = contaxt.IOProducts.Where(p => p.id == id).FirstOrDefault();
                _contaxt.locationid = newLocationid;
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

        public bool Delete(Guid id)
        {
            try
            {
                var _contaxt = contaxt.IOProducts.Where(p => p.id == id).FirstOrDefault();
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

        public ICollection<IOProduct> GetAll()
        {
            return contaxt.IOProducts.Where(p => p.Deleted == false).ToList();
        }
    }
}