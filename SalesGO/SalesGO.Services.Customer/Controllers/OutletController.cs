using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using Response.Const;
using SalesGO.Services.Customer.DataContext.Interfaces.IRepository;
using SalesGO.Services.Customer.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Threading.Tasks;

namespace SalesGO.Services.Customer.API.Controllers
{
    [Route("api/v1/Customer/[controller]")]
    [ApiController]
    public class OutletController : Controller
    {
        private readonly ILogger<OutletController> _logger;
        private readonly IUnitOfWork _context; 

        public OutletController(ILogger<OutletController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _context = unitOfWork;

        }

        [HttpPost()]
        public async Task<SalesGoResponse> CreateOutlet(Setup_Outlet _Outlet)
        {
            try
            {

                if (_Outlet != null && _Outlet.customerId != null && _Outlet.customerId != "")
                {
                    _Outlet.outletId = null;
                    var isCustomerExsist = await _context.Customer.FirstOrDefaultAsync(x => x.customerId == _Outlet.customerId);

                    if (isCustomerExsist != null)
                    {
                        var response = await _context.Customer.AddOutlet(_Outlet);
                        if (response == true)
                        {
                            return CustomRequest.CreateResponse(ApiResponseMessages.Inserted, true, _Outlet);

                        }
                    }

                    return CustomRequest.CreateResponse(ApiResponseMessages.NotFound, false, null);

                }

                return CustomRequest.CreateResponse(ApiResponseMessages.SomethingWentWrong, false, _Outlet);
            }
            catch (Exception ex)
            {
                return CustomRequest.CreateResponse(ex.Message, false, null);
            }
        }
    }
}
