using MongoDB.Driver;
using SalesGO.Services.Customer.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesGO.Services.Customer.DataContext.Interfaces.IContext
{
  
    public interface ICustomerContext
    {
        IMongoCollection<Setup_Customer> Setup_Customers { get; }

        IMongoCollection<TEntity> Set<TEntity>() where TEntity : class;


    }
}
