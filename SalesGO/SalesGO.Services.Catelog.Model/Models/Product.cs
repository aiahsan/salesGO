using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesGO.Services.Catelog.Model.Models
{
    public class Product : Base
    {
        [Key]
        public int productId { get; set; }

        [ForeignKey("subCategory")]
        public int subCategoryId { get; set; }
        public Product_SubCategory subCategory { get; set; } 
        
        public string image { get; set; }
        public string description { get; set; }
        public string productName { get; set; }
        public string skuCode { get; set; }

        [ForeignKey("brand")]
        public int brandId { get; set; }
        public Brand brand { get; set; }


        public ICollection<Product_SelectedField> Product_SelectedFields { get; set; }

    }
}
