using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesGO.Services.Catelog.Model.Models
{
    public class Product_subCategoryField
    {
        [Key]
        public int subCategoryFieldId { get; set; }

        //foreing key Product_Sub_Category
        [ForeignKey("productSubCategory")]
        public int subCategoryId { get; set; }
        public Product_subCategory productSubCategory { get; set; }

        public string fieldName { get; set; } = "";

        [ForeignKey("fieldType")]
        public int fieldTypeId { get; set; }

        public Setup_FieldType fieldType { get; set; }

        public string fieldPreValues { get; set; }

        [ForeignKey("fieldFormControl")]
        public int fieldFormControlId { get; set; }
        public Setup_FieldFormControl fieldFormControl { get; set; }





    }
}
