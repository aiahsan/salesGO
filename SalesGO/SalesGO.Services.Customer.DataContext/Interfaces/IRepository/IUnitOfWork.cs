using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesGO.Services.Customer.DataContext.Interfaces.IRepository
{
    public interface IUnitOfWork
    {
        ICustomer Customer { get; }


    }
}
