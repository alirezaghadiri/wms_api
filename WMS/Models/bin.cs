﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Key]
        public int binKey { get; set; }
        [NotMapped]
        public virtual product Product { get; set; }
        public int productid { get; set; }
        [NotMapped]
        public virtual Location location { get; set; }
        public int locationid { get; set; }
        public string Description { get; set; }
        public bool isactive { get; set; }

        //Delete
        [NotMapped]
        public virtual user DeletedUser { get; set; }
        public bool Deleted { get; set; }
        public DateTime? DeletedDate { get; set; }
        public int? DeletedByUserId { get; set; }

        //Created
        [NotMapped]
        public virtual user CreatedUser { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedByUserId { get; set; }

        //Changed
        [NotMapped]
        public virtual user ChangedUser { get; set; }
        public DateTime? ChangedDate { get; set; }
        public int? ChangedByUserId { get; set; }


        public static EntityTypeConfiguration<bin> Map()
        {
            var map = new EntityTypeConfiguration<bin>();
            map.Property(P => P.Description).HasMaxLength(1000);
            map.HasRequired(B => B.Product).WithMany(P => P.bins).HasForeignKey(B => B.productid);
            map.HasRequired(B => B.location).WithMany(l => l.bins).HasForeignKey(B => B.locationid);
            map.HasOptional(B => B.DeletedUser).WithMany(U => U.DeletedBin).HasForeignKey(P => P.DeletedByUserId).WillCascadeOnDelete(true);
            map.HasRequired(B => B.CreatedUser).WithMany(U => U.CreatedBin).HasForeignKey(P => P.CreatedByUserId).WillCascadeOnDelete(true);
            map.HasOptional(B => B.ChangedUser).WithMany(U => U.ChangedBin).HasForeignKey(P => P.ChangedByUserId).WillCascadeOnDelete(true);

            return map;
        }



    }
}