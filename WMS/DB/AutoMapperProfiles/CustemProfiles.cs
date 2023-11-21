using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using WMS.Models;
using dto = WMS.Models.DTO;

namespace WMS.DB.AutoMapperProfiles
{
    public class CustemProfiles: Profile
    {
        public CustemProfiles()
        {
            CreateMap<dto.user, user>();
            CreateMap<user, dto.user>();

            CreateMap<dto.product, product>();
            CreateMap<product, dto.product>();
        }
            
    }
}