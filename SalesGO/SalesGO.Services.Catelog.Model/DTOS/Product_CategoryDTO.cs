using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesGO.Services.Catelog.Model.DTOS
{
    public class Product_CategoryDTO : BaseDTO
    {
        
        public int? categoryId { get; set; }
        public string categoryName { get; set; } = "";

        
        public string businessId { get; set; } = ""; 
         

    }
}
