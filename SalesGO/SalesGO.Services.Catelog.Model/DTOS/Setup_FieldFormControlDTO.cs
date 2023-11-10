using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesGO.Services.Catelog.Model.DTOS
{
    public class Setup_FieldFormControlDTO : BaseDTO
    {
        
        public int fieldFormControlId { get; set; }

        public string fieldFormControl { get; set; }

        public bool allowPreValues { get; set; }
    }
}
