using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver.GeoJsonObjectModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThirdParty.Json.LitJson;
using NetTopologySuite.Geometries;

namespace SalesGO.Services.Customer.Model.Models
{
    public class Setup_Customer : Base
    {

        [Key]
        public int customerId { get; set; }
        public string? businessId { get; set; }= "";
        public string? customerBusinessName { get; set; }
        public string? customerTelephone { get; set; }
        public string? customerEmail { get; set; } 
        public string? customerContact { get; set; }
        public string? customerRepresentativeDesignation { get; set; } 
        public string? customerRepresentativeName { get; set; }  
        public string? customerAddress { get; set; }


        public  ICollection<Setup_Outlet> Outlets { get; set; }
         

    }

    

}
