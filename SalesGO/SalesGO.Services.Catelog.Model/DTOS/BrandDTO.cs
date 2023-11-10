using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesGO.Services.Catelog.Model.DTOS
{
    public class BrandDTO : BaseDTO
    {
         
        public int? brandId { get; set; }
        [Required]
        public string name { get; set; }
        [AllowNull]
        public string description { get; set; }
        [AllowNull]
        public string image { get; set; }

        [AllowNull]
        public string businessId { get; set; } 



    
    }
}
