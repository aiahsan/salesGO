using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesGO.Services.Catelog.Model.Models
{
    public class Setup_FieldType
    {
        [Key]
        public int fieldTypeId { get; set; }
        public string fieldName { get; set; }
    
    
    }
}
