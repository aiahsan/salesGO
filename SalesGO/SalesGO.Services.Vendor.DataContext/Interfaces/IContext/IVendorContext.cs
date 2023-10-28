using MongoDB.Driver;
using SalesGO.Services.Vendor.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesGO.Services.Vendor.DataContext.Interfaces.IContext
{
    public interface IVendorContext
    {
        IMongoCollection<Setup_Vendor> Setup_Vendors { get; }

        IMongoCollection<TEntity> Set<TEntity>() where TEntity : class;


    }
}
