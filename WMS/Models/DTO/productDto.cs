using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WMS.Models.DTO
{
    public class product
    {
        public int id { get; set; }
        public string artic { get; set; }
        public string title { get; set; }
        public string Description { get; set; }
        public bool isactive { get; set; }
    }
}