using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesGO.Services.Catelog.Interfaces.IRepository
{
    public interface IUnitOfWork
    {
        IBrandRepo BrandRepoObj { get;}
        IProductRepo ProductRepoObj { get;}
        IProductCategoryRepo ProductCategoryRepoObj { get;}
        IProductSelectedFieldRepo ProductSelectedFieldRepoObj { get;}
        IProductSubCategoryRepo ProductSubCategoryRepoObj { get;}
        IProductSubCategoryFieldRepo ProductSubCategoryFieldRepoObj { get;}
        ISetupFieldFormControlRepo SetupFieldFormControlRepoObj { get;}
        ISetupFieldTypeRepo SetupFieldTypeRepoObj { get;}


    }
}
