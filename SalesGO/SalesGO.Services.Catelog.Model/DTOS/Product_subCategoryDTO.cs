using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesGO.Services.Catelog.Model.DTOS
{
    public class Product_subCategoryDTO : BaseDTO
    {
         
        public int? subCategoryId { get; set; }
        public string subCategoryName { get; set; } = "";

       
        public int categoryId { get; set; }    


    }
}
