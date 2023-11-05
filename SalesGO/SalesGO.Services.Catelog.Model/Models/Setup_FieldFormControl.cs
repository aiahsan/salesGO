using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesGO.Services.Catelog.Model.Models
{
    public class Setup_FieldFormControl
    {
        [Key]
        public int fieldFormControlId { get; set; }

        public string fieldFormControl { get; set; }

        public bool allowPreValues { get; set; }   
    }
}
