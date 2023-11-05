using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesGO.Services.Catelog.Model.Models
{
    public class Product_SelectedField
    {
        [Key]
        public int productSelectedFieldId { get; set; }

        public int productSubCategoryFieldId { get; set; }
        

        public string selectedValue { get; set; }

        
        [ForeignKey("product")]
        public int productId { get; set; }
        public Product product { get; set; }


      
       
    }
}
