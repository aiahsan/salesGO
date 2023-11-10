using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesGO.Services.Catelog.Model.Models
{
    public class Product_SubCategory : Base
    {
        [Key]
        public int subCategoryId { get; set; }
        public string subCategoryName { get; set; } = "";

        //foreignkey
        [ForeignKey("productCategory")]
        public int categoryId { get; set; }
        public Product_Category productCategory { get; set; }


        public ICollection<Product_SubCategoryField> product_subCategoryFields { get; set; }
        public ICollection<Product> products { get; set; }
        

    }
}
