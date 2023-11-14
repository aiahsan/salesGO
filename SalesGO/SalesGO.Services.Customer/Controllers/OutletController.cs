using Const;
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




        [HttpGet()]
        public async Task<SalesGoResponse> Get()
        {
            try
            {


                var dataGet = await _context._OutletRepo.WhereAsync(x => x.isActive == true);
                return CustomRequest.CreateResponse(ApiResponseMessages.Retrieved, true, dataGet);

            }
            catch (Exception ex)
            {
                return CustomRequest.CreateResponse(ex.Message, false, null);
            }

        }


        [HttpGet("GetAllOutletInCustomRadius")]
        public async Task<SalesGoResponse> GetAllOutletInCustomRadius(double centerLat, double centerLong, double radiusMiles)
        {
            try
            {
                var dataGet = await _context._OutletRepo.GetOutletByRadius(centerLat, centerLong, radiusMiles);
                if (dataGet.Count() > 0)
                {

                    return CustomRequest.CreateResponse(ApiResponseMessages.Retrieved, true, dataGet);

                }
                else
                    return CustomRequest.CreateResponse(ApiResponseMessages.NotFound, false, dataGet);


            }
            catch (Exception ex)
            {
                return CustomRequest.CreateResponse(ex.Message, false, null);
            }

        }
        [HttpGet("{Id}")]
        public async Task<SalesGoResponse> Get(int Id)
        {
            try
            {
                var dataGet = await _context._OutletRepo.FirstOrDefaultAsync(x => x.outletId == Id);
                if (dataGet != null)
                {
                    return CustomRequest.CreateResponse(ApiResponseMessages.Retrieved, true, dataGet);

                }
                else
                    return CustomRequest.CreateResponse(ApiResponseMessages.NotFound, false, dataGet);


            }
            catch (Exception ex)
            {
                return CustomRequest.CreateResponse(ex.Message, false, null);
            }

        }

        [HttpGet("GetAllOutletInCustomRadiusByCustomer")]
        public async Task<SalesGoResponse> GetAllOutletInCustomRadiusByCustomer(double centerLat, double centerLong, double radiusMiles, int customerId)
        {
            try
            {
                var dataGet = await _context._OutletRepo.GetOutletByRadiusByCustomer(centerLat, centerLong, radiusMiles, customerId);
                if (dataGet.Count() > 0)
                {

                    return CustomRequest.CreateResponse(ApiResponseMessages.Retrieved, true, dataGet);

                }
                else
                    return CustomRequest.CreateResponse(ApiResponseMessages.NotFound, false, dataGet);


            }
            catch (Exception ex)
            {
                return CustomRequest.CreateResponse(ex.Message, false, null);
            }

        }

        [HttpGet("Filter")]
        public async Task<SalesGoResponse> Filter(int customerId, string outletAddress, string outletContact, string outletName, int page = 1, int limit = 1)
        {
            try
            {
                var predicate = PredicateBuilder.True<Setup_Outlet>();

                if (customerId != null)
                    predicate = predicate.And(x => x.customerId == customerId);

                if (!string.IsNullOrEmpty(outletAddress))
                    predicate = predicate.And(x => x.outletAddress.ToLower().Contains(outletAddress.ToLower()));

                if (!string.IsNullOrEmpty(outletContact))
                    predicate = predicate.And(x => x.outletContact.ToLower().Contains(outletContact.ToLower()));

                if (!string.IsNullOrEmpty(outletName))
                    predicate = predicate.And(x => x.outletName.ToLower().Contains(outletName.ToLower()));

                predicate = predicate.And(x => x.isActive == true);

                var dataGet = await _context._OutletRepo.BatchFiltersync(predicate, page, limit);

                return CustomRequest.CreateResponse(ApiResponseMessages.Retrieved, true, dataGet);
            }
            catch (Exception ex)
            {
                return CustomRequest.CreateResponse(ex.Message, false, null);
            }


        }

        [HttpGet("GetOutletsbyBusinessId/{Id}")]
        public async Task<SalesGoResponse> GetOutletsbyBusinessId(string Id)
        {
            try
            {
                var dataGet = await _context._OutletRepo.GetOutletsbyBusinessId(Id);
                if (dataGet.Count() > 0)
                {

                    return CustomRequest.CreateResponse(ApiResponseMessages.Retrieved, true, dataGet);

                }
                else
                    return CustomRequest.CreateResponse(ApiResponseMessages.NotFound, false, dataGet);


            }
            catch (Exception ex)
            {
                return CustomRequest.CreateResponse(ex.Message, false, null);
            }

        }

        [HttpGet("GetOutletsbyCustomerId/{Id}")]
        public async Task<SalesGoResponse> GetOutletsbyCustomerId(int Id)
        {
            try
            {
                var dataGet = await _context._OutletRepo.WhereAsync(x => x.customerId == Id && x.isActive == true);
                if (dataGet.Count() > 0)
                {
                    return CustomRequest.CreateResponse(ApiResponseMessages.Retrieved, true, dataGet);

                }
                else
                    return CustomRequest.CreateResponse(ApiResponseMessages.NotFound, false, dataGet);


            }
            catch (Exception ex)
            {
                return CustomRequest.CreateResponse(ex.Message, false, null);
            }

        }



        [HttpPost()]
        public async Task<SalesGoResponse> CreateOutlet(Setup_Outlet outlet)
        {
            try
            {

                if (outlet != null)
                {
                    
                   
                    var response = await _context._OutletRepo.InsertAsync(outlet);
                    if (response == true)
                    {
                        return CustomRequest.CreateResponse(ApiResponseMessages.Inserted, true, outlet);

                    }

                }

                return CustomRequest.CreateResponse(ApiResponseMessages.SomethingWentWrong, false, outlet);


            }
            catch (Exception ex)
            {
                return CustomRequest.CreateResponse(ex.Message, false, null);
            }
        }
         
        [HttpPut()]
        public async Task<SalesGoResponse> UpdateCustomer(Setup_Outlet _outlet)
        {
            try
            {
                if (_outlet != null && _outlet.outletId>0)
                {
                    var existingOutlet = await _context._OutletRepo
                        .FirstOrDefaultAsync(x => x.isActive == true && x.outletId == _outlet.outletId);

                    if (existingOutlet != null)
                    {
                        Type type = typeof(Setup_Customer);
                        PropertyInfo[] properties = type.GetProperties();

                    

                        foreach (var property in properties)
                        {
                            // Check if the property is writable
                            if (property.CanWrite)
                            {
                                object valueFromObj2 = property.GetValue(_outlet);
                                object valueFromObj1 = property.GetValue(existingOutlet);

                                // Only update if values are different
                                if (!object.Equals(valueFromObj1, valueFromObj2))
                                {
                                    if (valueFromObj2 != null)
                                    {
                                        property.SetValue(existingOutlet, valueFromObj2);
                                    }
                                }
                            }
                        }

                        var response = await _context._OutletRepo.UpdateAsync(existingOutlet, x => x.outletId == _outlet.outletId);

                        if (response == true)
                        {
                            return CustomRequest.CreateResponse(ApiResponseMessages.Updated, true, existingOutlet);
                        }
                        else
                        {
                            // Handle the case when the update is not successful
                            return CustomRequest.CreateResponse(ApiResponseMessages.SomethingWentWrong, false, null);
                        }
                    }

                }

                return CustomRequest.CreateResponse(ApiResponseMessages.SomethingWentWrong, false, _outlet);
            }
            catch (Exception ex)
            {
                return CustomRequest.CreateResponse(ex.Message, false, null);
            }
        }

        [HttpDelete()]
        public async Task<SalesGoResponse> Delete(int id)
        {
            try
            {
                if (id!=null && id>0)
                {
                    var _Data = await _context._OutletRepo.FirstOrDefaultAsync(x => x.isActive == true && x.outletId == id);
                    if (_Data != null)
                    {
                        _Data.isActive = false;
                        var response = await _context._OutletRepo.UpdateAsync(_Data, x => x.outletId == id);
                        if (response == true)
                        {
                            return CustomRequest.CreateResponse(ApiResponseMessages.Deleted, true, _Data);

                        }
                    }



                }

                return CustomRequest.CreateResponse(ApiResponseMessages.SomethingWentWrong, false, null);


            }
            catch (Exception ex)
            {
                return CustomRequest.CreateResponse(ex.Message, false, null);
            }
        }

      


       

    }
}
