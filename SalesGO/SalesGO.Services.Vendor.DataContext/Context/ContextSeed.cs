using MongoDB.Driver;
using SalesGO.Services.Vendor.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesGO.Services.Vendor.DataContext.Context
{
    public static class ContextSeed
    {
        public static void SeedData(IMongoCollection<Setup_Vendor> _Vendors)
        {
            bool exsistCategory = _Vendors.Find(x => true).Any();

            if (!exsistCategory)
            {
                _Vendors.InsertManyAsync(new List<Setup_Vendor>()
                {
                    new Setup_Vendor()
                        {
                            vendorId = "641cb427b85f9475a34046a9",
                            businessId="1",
                            CreatedAt = DateTime.Now,
                            IsActive = true,
                            CreatedBy="-1",
                            vendorAddress="xyz street",
                            vendorBusinessName="Halal Foods",
                            vendorCity="Karachi",
                            vendorContact="+012356789",
                            vendorCountry="Pakistan",
                            vendorRegion="South",
                            vendorEmail="vendor@mail.com",
                            vendorName="ABC Vendor",
                            vendorTelephone="909902213"
                        },

                });
            }

        }

    }
}
