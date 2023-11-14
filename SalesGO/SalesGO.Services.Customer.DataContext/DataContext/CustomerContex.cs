using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using SalesGO.Services.Customer.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesGO.Services.Customer.DataContext.DataContext
{
    public partial class CustomerContext : DbContext
    {
        public CustomerContext(DbContextOptions<CustomerContext> options) : base(options)
        {
            ContextSeed.SeedData(this);
        }
        
        public DbSet<Setup_Outlet> Setup_Outlet { get; set; }
        public DbSet<Setup_Customer> Setup_Customers { get; set; }
    }
}
