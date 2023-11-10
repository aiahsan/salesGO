using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesGO.Services.Catelog.Model.DTOS
{
    public class Product_subCategoryFieldDTO : BaseDTO
    {
         
        public int subCategoryFieldId { get; set; }

         
        public int subCategoryId { get; set; }
         

        public string fieldName { get; set; } = "";

         public int fieldTypeId { get; set; }

 
        public string fieldPreValues { get; set; } = "";

        public int fieldFormControlId { get; set; } = "";



    }
}
