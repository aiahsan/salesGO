using SalesGO.Services.Customer.Model.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesGO.Services.Customer.Model.DTOS
{
    public class CustomerDTO
    {
        
        public int customerId { get; set; }
        public string? businessId { get; set; } = "";
        public string? customerBusinessName { get; set; }
        public string? customerTelephone { get; set; }
        public string? customerEmail { get; set; }
        public string? customerContact { get; set; }
        public string? customerRepresentativeDesignation { get; set; }
        public string? customerRepresentativeName { get; set; }
        public string? customerAddress { get; set; } 
        public ICollection<Setup_Outlet> Outlets { get; set; }
    }
}
