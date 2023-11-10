using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesGO.Services.Catelog.Model.Models
{
    public class Product_Category : Base
    {
        [Key]
        public int categoryId { get; set; }
        public string categoryName { get; set; } = "";

        //business foreignkey
        public string businessId { get; set; }= "";


        public ICollection<Product_SubCategory> product_subCategories { get; set; }

    }
}
