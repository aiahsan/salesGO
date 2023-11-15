using SalesGO.Services.Customer.Model.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesGO.Services.Customer.Model.DTOS
{
    public class OutletDTO
    {
       
        public int outletId { get; set; }

        public int customerId { get; set; }
        public double outletLat { get; set; }
        public double outletLong { get; set; }
        public string outletAddress { get; set; } = "";
        public string outletImage { get; set; } = "";
        public string outletContact { get; set; } = "";
        public string outletName { get; set; } = "";

        public Setup_Customer Customer { get; set; }

    }
}
