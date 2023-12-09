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
        public DbSet<bin> Bins { get; set; }
        public DbSet<product> products { get; set; }
        public DbSet<IIOProduct> IOProducts { get; set; }
        public DbSet<Location> locations { get; set; }

    }

    public class DbInitializer : CreateDatabaseIfNotExists<WMSDBContext>
    {
        protected override void Seed(WMSDBContext context)
        {
            var contaxt = new WMSDBContext();
            contaxt.Users.Add(new user()
            {
                First_Name = "Supper",
                Last_Name = "user",
                id = 1,
                active = true,
                username = "administrator"
            });

            contaxt.Users.Add(new user
            {
                First_Name = "رضا",
                Last_Name = "حسن پور",
                id = 2,
                active = true,
                username = "rhasanpor"
            });
            contaxt.SaveChanges();


            base.Seed(context);
        }
    }
}