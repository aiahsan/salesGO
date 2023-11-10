
using SalesGO.Services.Catelog.DataContext.DataContext;
using SalesGO.Services.Catelog.Interfaces.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesGO.Services.Catelog.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            this._context = context;
            BrandRepoObj = new BrandRepo(context);
            ProductRepoObj = new ProductRepo(context);
            ProductCategoryRepoObj = new ProductCategoryRepo(context);
            ProductSelectedFieldRepoObj = new ProductSelectedFieldRepo(context);
            ProductSubCategoryRepoObj = new ProductSubCategoryRepo(context);
            ProductSubCategoryFieldRepoObj = new ProductSubCategoryFieldRepo(context);
            SetupFieldFormControlRepoObj = new SetupFieldFormControlRepo(context);
            SetupFieldTypeRepoObj = new SetupFieldTypeRepo(context);
            
        }
 
        public IBrandRepo BrandRepoObj { get;private set; }

        public IProductRepo ProductRepoObj { get;private set; }

        public IProductCategoryRepo ProductCategoryRepoObj { get;private set; }

        public IProductSelectedFieldRepo ProductSelectedFieldRepoObj { get;private set; }

        public IProductSubCategoryRepo ProductSubCategoryRepoObj { get;private set; }

        public IProductSubCategoryFieldRepo ProductSubCategoryFieldRepoObj { get;private set; }

        public ISetupFieldFormControlRepo SetupFieldFormControlRepoObj { get;private set; }

        public ISetupFieldTypeRepo SetupFieldTypeRepoObj { get;private set; }
    }
}
