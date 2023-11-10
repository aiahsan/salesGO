using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesGO.Services.Catelog.Model.DTOS
{
    public class ProductDTO : BaseDTO
    {
      
        public int? productId { get; set; }

       
        public int subCategoryId { get; set; }

        public string image { get; set; } = "";
        public string description { get; set; } = "";
        public string productName { get; set; } = "";
        public string skuCode { get; set; } = "";
        public int? brandId { get; set; }
       

    }
}
