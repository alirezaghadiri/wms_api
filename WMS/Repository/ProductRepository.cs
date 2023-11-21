using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WMS.DB;
using WMS.IRepository;
using WMS.Models;

namespace WMS.Repository
{
    public class ProductRepository : IProduct
    {
        private WMSDBContext contaxt { get; set; }
        public ProductRepository()
        {
            contaxt = new WMSDBContext();
        }

        public bool Add(product _product)
        {
            try
            {
                _product.CreatedDate = DateTime.Now;
                _product.CreatedByUserId = 1;
                contaxt.products.Add(_product);
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
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            try
            {
                var _contaxt = contaxt.products.Where(p => p.id == id).FirstOrDefault();
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

        public product Find(int id)
        {
            try
            {
                return contaxt.products
                .Where(p => p.id == id).FirstOrDefault();
            }
            catch
            {
                return null;
            }
        }

        public ICollection<product> GetAll()
        {
            return contaxt.products.ToList();
        }

        public bool Update(product _product)
        {
            try
            {
                var _contaxt = contaxt.products.Where(p => p.id == _product.id).FirstOrDefault();
                _contaxt.title = _product.title;
                _contaxt.artic=_product.artic;
                _contaxt.isactive=_product.isactive;
                _contaxt.Description = _product.Description;
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

        public product FindByArtic(string artic)
        {
            try
            {
                return contaxt.products
                .Where(p => p.artic == artic).FirstOrDefault();
            }
            catch
            {
                return null;
            }
        }
    }
}