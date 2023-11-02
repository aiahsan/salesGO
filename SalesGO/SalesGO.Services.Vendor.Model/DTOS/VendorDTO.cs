using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;

namespace SalesGO.Services.Vendor.Model.DTOS
{
    public class VendorDTO: BaseDTO
    {

        public string vendorId { get; set; } = "";
        public string businessId { get; set; } = "";
        public string vendorName { get; set; } = "";
        public string vendorBusinessName { get; set; } = "";
        public string vendorTelephone { get; set; } = "";
        public string vendorEmail { get; set; } = "";
        public string vendorContact { get; set; } = "";

        public string vendorCity { get; set; } = "";

        public string vendorRegion { get; set; } = "";

        public string vendorCountry { get; set; } = "";
        public string vendorAddress { get; set; } = "";
    }
}
