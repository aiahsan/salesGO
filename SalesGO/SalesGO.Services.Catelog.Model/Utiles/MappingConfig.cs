using AutoMapper;
using SalesGO.Services.Catelog.Model.DTOS;
using SalesGO.Services.Catelog.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesGO.Services.Catelog.Model.Utiles
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<Brand,BrandDTO>().ReverseMap();
                config.CreateMap<Product, ProductDTO>().ReverseMap();
                config.CreateMap<Product_Category, Product_CategoryDTO>().ReverseMap();
                config.CreateMap<Product_SelectedField, Product_SelectedFieldDTO>().ReverseMap();
                config.CreateMap <Product_SubCategory, Product_subCategoryDTO>().ReverseMap();
                config.CreateMap<Product_SubCategoryField, Product_subCategoryFieldDTO>().ReverseMap();
                config.CreateMap<Setup_FieldFormControl, Setup_FieldFormControlDTO>().ReverseMap();
                config.CreateMap<Setup_FieldType, Setup_FieldTypeDTO>().ReverseMap();


            });


            return mappingConfig;
        }
    }
}
