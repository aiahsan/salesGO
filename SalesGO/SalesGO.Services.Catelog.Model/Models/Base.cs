using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesGO.Services.Catelog.Model.Models
{
    public class Base
    {
        public string createdBy { get; set; } = "";
        public DateTime createdAt { get; set; } = DateTime.Now;
        public DateTime? updatedAt { get; set; } 
        public string? updatedBy { get; set; } = "";
        public bool isActive { get; set; } = true;
    }
}
