using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesGO.Services.Catelog.Model.Models
{
    public class Brand:Base
    {
        [Key]
        public int brandId { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string image { get; set; }

        //foreignkey
        public string businessId { get; set; }


        public ICollection<Product> products { get; set; }
    }
}
