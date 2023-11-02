using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using SalesGO.Services.Vendor.DataContext.Interfaces.IContext;
using SalesGO.Services.Vendor.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesGO.Services.Vendor.DataContext.Context
{
    public partial class VendorContext : IVendorContext
    {
         public VendorContext(IConfiguration configuration)
        {


 
            var client = new MongoClient(configuration["DatabaseSettings:ConnectionString"]);
            var database = client.GetDatabase(configuration["DatabaseSettings:DatabaseName"]);

            Setup_Vendors = database.GetCollection<Setup_Vendor>("Setup_Vendors");
            

            ContextSeed.SeedData(Setup_Vendors);
        }
        public IMongoCollection<Setup_Vendor> Setup_Vendors { get; }

        public IMongoCollection<TEntity> Set<TEntity>() where TEntity : class
        {
            if (typeof(TEntity) == typeof(Setup_Vendor))
            {
                return (IMongoCollection<TEntity>)Setup_Vendors;
            }

            throw new NotImplementedException("Collection Not found");
        }
    }
}
