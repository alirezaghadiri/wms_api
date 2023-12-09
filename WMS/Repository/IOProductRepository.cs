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
            throw new NotImplementedException();
        }

        public bool Update(IOProduct _IOProduct)
        {
            throw new NotImplementedException();
        }

        public bool changeLocation(int id, int newLocationid)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<IOProduct> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}