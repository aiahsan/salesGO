
using SalesGO.Services.Catelog.DataContext.DataContext;
using SalesGO.Services.Catelog.Interfaces.IRepository;
using SalesGO.Services.Catelog.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesGO.Services.Catelog.Repository
{
    public class BrandRepo : Repository<Brand>, IBrandRepo
    {
        private readonly ApplicationDbContext _context;

        public BrandRepo(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
          
    }

    public class ProductRepo : Repository<Product>, IProductRepo
    {
        private readonly ApplicationDbContext _context;

        public ProductRepo(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

    }
    public class ProductCategoryRepo : Repository<Product_Category>, IProductCategoryRepo
    {
        private readonly ApplicationDbContext _context;

        public ProductCategoryRepo(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

    }  
    
    
    
    
    public class ProductSubCategoryRepo : Repository<Product_SubCategory>, IProductSubCategoryRepo
    {
        private readonly ApplicationDbContext _context;

        public ProductSubCategoryRepo(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

    }
    
    
    public class ProductSubCategoryFieldRepo : Repository<Product_SubCategoryField>, IProductSubCategoryFieldRepo
    {
        private readonly ApplicationDbContext _context;

        public ProductSubCategoryFieldRepo(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

    }
    
    
    public class ProductSelectedFieldRepo : Repository<Product_SelectedField>, IProductSelectedFieldRepo
    {
        private readonly ApplicationDbContext _context;

        public ProductSelectedFieldRepo(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

    }  
    


    public class SetupFieldFormControlRepo : Repository<Setup_FieldFormControl>, ISetupFieldFormControlRepo
    {
        private readonly ApplicationDbContext _context;

        public SetupFieldFormControlRepo(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

    }  


    public class SetupFieldTypeRepo : Repository<Setup_FieldType>, ISetupFieldTypeRepo
    {
        private readonly ApplicationDbContext _context;

        public SetupFieldTypeRepo(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

    }

}
