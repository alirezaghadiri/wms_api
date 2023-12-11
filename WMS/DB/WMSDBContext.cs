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
        public DbSet<Role> Roles { get; set; }
        public DbSet<bin> Bins { get; set; }
        public DbSet<product> products { get; set; }
        public DbSet<IOProduct> IOProducts { get; set; }
        public DbSet<Location> locations { get; set; }

    }

    public class DbInitializer : CreateDatabaseIfNotExists<WMSDBContext>
    {
        protected override void Seed(WMSDBContext context)
        {
            var contaxt = new WMSDBContext();
            var slat = Guid.NewGuid().ToString("N");
            contaxt.Users.Add(new user()
            {
                First_Name = "Supper",
                Last_Name = "user",
                id = 1,
                active = true,
                username = "administrator",
                PasswordSalt = slat,
                password = utiles.Tools.hashedPassword("258", slat)
            });
            slat = Guid.NewGuid().ToString("N");
            contaxt.Users.Add(new user
            {
                First_Name = "رضا",
                Last_Name = "حسن پور",
                id = 2,
                active = true,
                username = "rhasanpor",
                PasswordSalt = slat,
                password = utiles.Tools.hashedPassword("", slat)
            });


            contaxt.SaveChanges();
            contaxt.Roles.Add(new Role()
            {
                RoleId = 1,
                Title = "admin",
                Users = contaxt.Users.Where(p => p.username == "administrator").ToList()
            });
            contaxt.Roles.Add(new Role()
            {
                RoleId = 1,
                Title = "lift",
                Users = contaxt.Users.Where(p => p.username != "administrator").ToList()
            });
            contaxt.SaveChanges();
            base.Seed(context);
        }
    }
}