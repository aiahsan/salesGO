 using SalesGO.Services.Catelog.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesGO.Services.Catelog.Interfaces.IRepository
{
     
    public interface IBrandRepo:IRepository<Brand>
    {
         
    }

    public interface IProductRepo : IRepository<Product>
    {

    }

    public interface IProductCategoryRepo : IRepository<Product_Category>
    {

    }

    public interface IProductSelectedFieldRepo : IRepository<Product_SelectedField>
    {

    }


    public interface IProductSubCategoryRepo : IRepository<Product_SubCategory>
    {

    }

    public interface IProductSubCategoryFieldRepo : IRepository<Product_SubCategoryField>
    {

    }


    public interface ISetupFieldFormControlRepo : IRepository<Setup_FieldFormControl>
    {

    }


    public interface ISetupFieldTypeRepo : IRepository<Setup_FieldType>
    {

    }

   

}
