using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace WMS.Models
{
    public class bin
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int binKey { get; set; }
        public virtual product Product { get; set; }
        public int product_id { get; set; }

        public virtual Location location { get; set; }
        public int location_id { get; set; }
        public string Description { get; set; }
        public bool isactive { get; set; }

        //Delete
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


        public static EntityTypeConfiguration<bin> Map()
        {
            var map = new EntityTypeConfiguration<bin>();
            map.Property(P => P.Description).HasMaxLength(1000);
            map.HasRequired(B => B.Product).WithMany(P=>P.bins).HasForeignKey(B => B.product_id);
            map.HasRequired(B => B.location).WithMany(l => l.bins).HasForeignKey(B => B.location_id);
            map.HasOptional(B => B.DeletedUser).WithMany(U => U.DeletedBin).HasForeignKey(P => P.DeletedByUserId);
            map.HasRequired(B => B.CreatedUser).WithMany(U => U.CreatedBin).HasForeignKey(P => P.CreatedByUserId).WillCascadeOnDelete(false);
            map.HasOptional(B => B.ChangedUser).WithMany(U => U.ChangedBin).HasForeignKey(P => P.ChangedByUserId);
            return map;
        }



    }
}