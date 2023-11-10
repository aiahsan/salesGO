using Microsoft.EntityFrameworkCore;
using SalesGO.Services.Catelog.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesGO.Services.Catelog.DataContext.DataContext
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Product_Category> Product_Categories{ get; set; }
        public DbSet<Product_SelectedField> Product_SelectedFields { get; set; }
        public DbSet<Product_SubCategory> Product_subCategories { get; set; }
        public DbSet<Product_SubCategoryField> Product_subCategoryFields { get; set; }
        public DbSet<Setup_FieldFormControl> Setup_FieldFormControls { get; set; }
        public DbSet<Setup_FieldType> Setup_FieldTypes { get; set; }
    }
}
