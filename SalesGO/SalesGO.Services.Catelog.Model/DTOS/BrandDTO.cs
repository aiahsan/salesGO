using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesGO.Services.Catelog.Model.DTOS
{
    public class BrandDTO : BaseDTO
    {
         
        public int? brandId { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string image { get; set; }

        public string businessId { get; set; }



    
    }
}
