using AutoMapper;
using SalesGO.Services.Vendor.Model.DTOS;
using SalesGO.Services.Vendor.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesGO.Services.Vendor.Model.Utiles
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<VendorDTO, Setup_Vendor>().ReverseMap();
 

            });

 
            return mappingConfig;
        }
    }
}
