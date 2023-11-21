using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace WMS.Models
{
    public partial class user
    {
        //Product
        public virtual ICollection<product> DeletedProduct { get; set; }
        public virtual ICollection<product> CreatedProduct { get; set; }
        public virtual ICollection<product> ChangedProduct { get; set; }



        public static EntityTypeConfiguration<user> Map()
        {
            var map = new EntityTypeConfiguration<user>();
            map.Property(U => U.username).HasMaxLength(100).IsRequired();
            map.Property(U => U.password).HasMaxLength(100).IsRequired();
            map.Property(U => U.PasswordSalt).HasMaxLength(100).IsRequired();
            map.Property(U => U.username).HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("Ix_Username_Unique") { IsUnique = true }));
            return map;
        }
    }
}