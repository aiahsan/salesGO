using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using SalesGO.Services.Customer.DataContext.Interfaces.IContext;
using SalesGO.Services.Customer.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesGO.Services.Customer.DataContext.DataContext
{
    public partial class CustomerContext : ICustomerContext
    {
        public CustomerContext(IConfiguration configuration)
        {



            var client = new MongoClient(configuration["DatabaseSettings:ConnectionString"]);
            var database = client.GetDatabase(configuration["DatabaseSettings:DatabaseName"]);

            Setup_Customers = database.GetCollection<Setup_Customer>("Setup_Customers");

            
        }
        public IMongoCollection<Setup_Customer> Setup_Customers { get; }

        public IMongoCollection<TEntity> Set<TEntity>() where TEntity : class
        {
            if (typeof(TEntity) == typeof(Setup_Customer))
            {
                return (IMongoCollection<TEntity>)Setup_Customers;
            }

            throw new NotImplementedException("Collection Not found");
        }
    }
}
