using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using MongoDB.Driver;
using SalesGO.Services.Customer.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesGO.Services.Customer.DataContext.DataContext
{
    public static class ContextSeed
    {
        public static void SeedData(CustomerContext _context)
        {

            bool exsistCustomers = _context.Setup_Customers.Any();

            if (!exsistCustomers)
            {
                for (int i = 1; i <= 1000; i++)
                {
                    var setupCustomer = new Setup_Customer
                    {
                        // Populate other properties...
                        businessId = $"123456789{i}",
                        customerBusinessName = $"CustomerBusiness{i}",
                        customerTelephone = $"123456789{i}",
                        customerEmail = $"customer{i}@example.com",
                        customerContact = $"John Doe {i}",
                        customerRepresentativeDesignation = $"Manager {i}",
                        customerRepresentativeName = $"Jane Doe {i}",
                        customerAddress = $"{i} Main St",
                        createdBy = $"User{i}",
                        createdAt = DateTime.Now,
                        isActive = true
                    };

                    // Insert the Setup_Customer record
                    _context.Setup_Customers.Add(setupCustomer);
                    _context.SaveChanges();
                    _context.Setup_Outlet.AddRangeAsync(GenerateDummyOutlets(i, setupCustomer.customerId));
                    _context.SaveChanges();
                }

             }


            static List<Setup_Outlet> GenerateDummyOutlets(int customerNumber,int _CustomerId)
            {
                var outlets = new List<Setup_Outlet>();
                for (int j = 1; j <= 100; j++)
                {
                    outlets.Add(new Setup_Outlet
                    {
                        
                        customerId = _CustomerId,
                        outletLat = 40.7128 + (0.1 * customerNumber) + (0.01 * j),
                        outletLong = -74.0060 - (0.1 * customerNumber) - (0.01 * j),
                        outletAddress = $"{j} Market St",
                        outletImage = $"outlet{j}_{j}.jpg",
                        outletContact = $"Outlet Contact {j}",
                        outletName = $"Outlet {j}",
                         createdBy = $"User{j}",
                        createdAt = DateTime.Now,
                        isActive = true
                    });
                }
                return outlets;
            }

        }

    }
}
