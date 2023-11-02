using SalesGO.Services.Vendor.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesGO.Services.Vendor.DataContext.Interfaces.IRepository
{
    public interface IVendor:IRepository<Setup_Vendor>
    {
        Task<IEnumerable<Setup_Vendor>> GetDataByBusinessId(string id);
    }
    
}
