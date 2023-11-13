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
        public static void SeedData(IMongoCollection<Setup_Customer> _Customers)
        {

            bool exsistCustomers = _Customers.Find(x => true).Any();

            if (!exsistCustomers)
            {
                for (int i = 1; i <= 60; i++)
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
                        Outlets = GenerateDummyOutlets(i),
                        createdBy = $"User{i}",
                        createdAt = DateTimeOffset.Now,
                        isActive = true
                    };

                    // Insert the Setup_Customer record
                    _Customers.InsertOne(setupCustomer);
                }

             }


            static List<Setup_Outlet> GenerateDummyOutlets(int customerNumber)
            {
                var outlets = new List<Setup_Outlet>();
                for (int j = 1; j <= 50; j++)
                {
                    outlets.Add(new Setup_Outlet
                    {
                        outletId = ObjectId.GenerateNewId().ToString(),
                        outletLat = 40.7128 + (0.1 * customerNumber) + (0.01 * j),
                        outletLong = -74.0060 - (0.1 * customerNumber) - (0.01 * j),
                        outletAddress = $"{j} Market St",
                        outletImage = $"outlet{j}_{j}.jpg",
                        outletContact = $"Outlet Contact {j}",
                        outletName = $"Outlet {j}"
                    });
                }
                return outlets;
            }

        }

    }
}
