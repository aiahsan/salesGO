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

    public class Setup_Outlet : Base
    {
        [Key]
        public int outletId { get; set; }

        public int customerId { get; set; }
        public NetTopologySuite.Geometries.Point Location { get; set; }

        public double outletLat { get; set; }
        public double outletLong{get;set;}
        public string outletAddress { get; set; } = "";
        public string outletImage { get; set; } = "";
        public string outletContact { get; set; } = "";
        public string outletName { get; set; } = "";


        [ForeignKey("customerId")]
        
        public Setup_Customer Customer { get; set; }

         


    }


}
