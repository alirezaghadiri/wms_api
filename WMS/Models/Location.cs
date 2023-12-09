using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace WMS.Models
{
    public class Location
    {
        public int id { get; set; }
        public int line { get; set; }
        public int Row { get; set; }
        public int column { get; set; }
        public string Description { get; set; }
        public  int State { get; set; }
        public bool isactive { get; set; }
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

        //bin
        public virtual ICollection<bin> bins { get; set; }

        //IOprodouct
        public virtual ICollection<IIOProduct> IOProducts { get; set; }


        public static EntityTypeConfiguration<Location> Map()
        {
            var map = new EntityTypeConfiguration<Location>();
            map.Property(l=> l.Description).HasMaxLength(1000);
            map.HasOptional(B => B.DeletedUser).WithMany(U => U.DeletedLocation).HasForeignKey(P => P.DeletedByUserId);
            map.HasRequired(B => B.CreatedUser).WithMany(U => U.CreatedLocation).HasForeignKey(P => P.CreatedByUserId).WillCascadeOnDelete(false);
            map.HasOptional(B => B.ChangedUser).WithMany(U => U.ChangedLocation).HasForeignKey(P => P.ChangedByUserId);
            return map;
        }


    }
}