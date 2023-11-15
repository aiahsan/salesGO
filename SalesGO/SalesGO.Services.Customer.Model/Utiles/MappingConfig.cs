using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SalesGO.Services.Customer.Model.DTOS;
using SalesGO.Services.Customer.Model.Models;

namespace SalesGO.Services.Customer.Model.Utiles
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<Setup_Outlet, OutletDTO>().ReverseMap();
                config.CreateMap<Setup_Customer, CustomerDTO>().ReverseMap();
                
            });


            return mappingConfig;
        }
    }
}
