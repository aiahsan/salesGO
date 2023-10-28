using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesGO.Services.Vendor.Model.Models
{
    public class Base
    {
        public string CreatedBy { get; set; } = "";
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.Now;
        public DateTimeOffset? UpdatedAt { get; set; } = DateTimeOffset.Now;
        public string? UpdatedBy { get; set; } = "";
        public bool IsActive { get; set; } = true;
    }
}
