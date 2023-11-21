using System;
using System.Collections.Generic;
using System.Data.Entity;
using WMS.Models;
using System.Linq;
using System.Web;

namespace WMS.DB
{
    public class WMSDBContext : DbContext
    {
        public WMSDBContext()
        {
            Database.SetInitializer(new DbInitializer());
        }
        public DbSet<user> Users { get; set; }
        public DbSet<product> products { get; set; }

    }

    public class DbInitializer : CreateDatabaseIfNotExists<WMSDBContext>
    {
        protected override void Seed(WMSDBContext context)
        {
            var contaxt = new WMSDBContext();

            user user = new user();
            user.First_Name = "رضا";
            user.Last_Name = "حسن پور";
            user.id = 1;
            user.active = true;
            user.username = "rhasanpor";
            contaxt.Users.Add(user);
            contaxt.SaveChanges();


            base.Seed(context);
        }
    }
}