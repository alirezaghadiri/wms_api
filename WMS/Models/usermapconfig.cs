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
        [NotMapped]
        public virtual ICollection<product> DeletedProduct { get; set; }
        [NotMapped]
        public virtual ICollection<product> CreatedProduct { get; set; }
        [NotMapped]
        public virtual ICollection<product> ChangedProduct { get; set; }


        //Bin
        [NotMapped]
        public virtual ICollection<bin> DeletedBin { get; set; }
        [NotMapped]
        public virtual ICollection<bin> CreatedBin { get; set; }
        [NotMapped]
        public virtual ICollection<bin> ChangedBin { get; set; }


        //location
        [NotMapped]
        public virtual ICollection<Location> DeletedLocation { get; set; }
        [NotMapped]
        public virtual ICollection<Location> CreatedLocation { get; set; }
        [NotMapped]
        public virtual ICollection<Location> ChangedLocation { get; set; }


        //IOproduct
        [NotMapped]
        public virtual ICollection<IOProduct> DeletedIOproduct { get; set; }
        [NotMapped]
        public virtual ICollection<IOProduct> CreatedIOproduct { get; set; }
        [NotMapped]
        public virtual ICollection<IOProduct> ChangedIOproduct { get; set; }

        //Role
        [NotMapped]
        public virtual ICollection<Role> Roles { get; set; }


        public static EntityTypeConfiguration<user> Map()
        {
            var map = new EntityTypeConfiguration<user>();
            map.Property(U => U.username).HasMaxLength(100).IsRequired();
            map.Property(U => U.password).HasMaxLength(100).IsRequired();
            map.Property(U => U.PasswordSalt).HasMaxLength(100).IsRequired();
            map.HasMany(U => U.Roles).WithMany(R => R.Users).Map(_map => _map.MapLeftKey("UserId").MapRightKey("RoleId").ToTable("UsersRoles"));
            map.Property(U => U.username).HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("Ix_Username_Unique") { IsUnique = true }));
            return map;
        }
    }
}