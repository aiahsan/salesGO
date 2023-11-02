using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesGO.Services.Customer.Model.DTOS
{
    public class BaseDTO
    {

        public string createdBy { get; set; } = "";
        public DateTimeOffset createdAt { get; set; } = DateTimeOffset.Now;
        public DateTimeOffset? updatedAt { get; set; } = DateTimeOffset.Now;
        public string? updatedBy { get; set; } = "";
        public bool isActive { get; set; } = true;

    }
}
