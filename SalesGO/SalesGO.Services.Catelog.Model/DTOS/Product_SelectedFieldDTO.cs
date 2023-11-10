using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesGO.Services.Catelog.Model.DTOS
{
    public class Product_SelectedFieldDTO : BaseDTO
    {
       
        public int? productSelectedFieldId { get; set; }

        public int productSubCategoryFieldId { get; set; }


        public string selectedValue { get; set; } = string.Empty;
        public int productId { get; set; }
         




    }
}
