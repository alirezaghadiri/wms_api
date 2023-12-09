using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace WMS.Models
{
    public class IOProduct
    {
        public Guid id { get; set; }
        public virtual product Product { get; set; }
        public int productId { get; set; }
        public virtual Location location { get; set; }
        public int locationid { get; set; }
        public DateTime Iputdate { get; set; }
        public bool flag { get; set; }
        public string Description { get; set; }

        //delete
        public virtual user DeletedUser { get; set; }
        public bool Deleted { get; set; }
        public DateTime? DeletedDate { get; set; }
        public int? DeletedByUserId { get; set; }

        //Created
        public virtual user CreatedUser { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedByUserId { get; set; }

        //Changed
        public virtual user ChangedUser { get; set; }
        public DateTime? ChangedDate { get; set; }
        public int? ChangedByUserId { get; set; }

        public static EntityTypeConfiguration<IIOProduct> Map()
        {
            var map = new EntityTypeConfiguration<IIOProduct>();
            map.Property(l => l.Description).HasMaxLength(1000);
            map.HasRequired(B => B.Product).WithMany(P => P.IOProducts).HasForeignKey(B => B.productId);
            map.HasRequired(B => B.location).WithMany(l => l.IOProducts).HasForeignKey(B => B.locationid);
            map.HasOptional(B => B.DeletedUser).WithMany(U => U.DeletedIOproduct).HasForeignKey(P => P.DeletedByUserId);
            map.HasRequired(B => B.CreatedUser).WithMany(U => U.CreatedIOproduct).HasForeignKey(P => P.CreatedByUserId).WillCascadeOnDelete(false);
            map.HasOptional(B => B.ChangedUser).WithMany(U => U.ChangedIOproduct).HasForeignKey(P => P.ChangedByUserId);
            return map;
        }



    }
}