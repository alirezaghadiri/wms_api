using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WMS.Models
{
    public partial class user
    {
        public int id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string username { get;set; }
        public string password { get; set; }
        public string PasswordSalt { get; set; }
        public bool active { get; set; }
    }
}