using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace WMS.Models
{
    public class product
    {
        public int id { get; set; }
        public string artic { get; set; }
        public string title { get; set; }
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

        //bin
        public virtual ICollection<bin> bins { get; set; }

        //IOprodouct
        public virtual ICollection<IIOProduct> IOProducts { get; set; }

        public static EntityTypeConfiguration<product> Map()
        {
            var map = new EntityTypeConfiguration<product>();
            map.Property(P => P.title).HasMaxLength(200).IsRequired();
            map.Property(P => P.Description).HasMaxLength(1000);
            map.Property(P => P.artic).HasMaxLength(7).IsRequired();
            map.Property(p => p.artic).HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("Ix_artic_Unique") { IsUnique = true }));
            map.HasOptional(C => C.DeletedUser).WithMany(U => U.DeletedProduct).HasForeignKey(P => P.DeletedByUserId);
            map.HasRequired(C => C.CreatedUser).WithMany(U => U.CreatedProduct).HasForeignKey(P => P.CreatedByUserId).WillCascadeOnDelete(false);
            map.HasOptional(C => C.ChangedUser).WithMany(U => U.ChangedProduct).HasForeignKey(P => P.ChangedByUserId);
            return map;
        }


    }
}