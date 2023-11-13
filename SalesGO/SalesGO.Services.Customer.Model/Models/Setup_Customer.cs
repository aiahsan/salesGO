using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver.GeoJsonObjectModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesGO.Services.Customer.Model.Models
{
    public class Setup_Customer : Base
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? customerId { get; set; }
        public string? businessId { get; set; }= "";
        public string? customerBusinessName { get; set; }
        public string? customerTelephone { get; set; }
        public string? customerEmail { get; set; } 
        public string? customerContact { get; set; }
        public string? customerRepresentativeDesignation { get; set; } 
        public string? customerRepresentativeName { get; set; }  
        public string? customerAddress { get; set; } 

        public List<Setup_Outlet> Outlets { get; set; } = new List<Setup_Outlet>();

    }

    public class Setup_Outlet
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string outletId { get; set; }
        public string customerId { get; set; } = "";
        public double outletLat { get; set; }
        public double outletLong { get; set; }
        public string outletAddress { get; set; } = "";
        public string outletImage { get; set; } = "";
        public string outletContact { get; set; } = "";
        public string outletName { get; set; } = "";



    }


}
