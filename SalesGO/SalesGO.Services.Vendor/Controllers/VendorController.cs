using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Driver;
using Response.Const;
using SalesGO.Services.Vendor.DataContext.Interfaces.IRepository;
using SalesGO.Services.Vendor.Model.DTOS;
using SalesGO.Services.Vendor.Model.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SalesGO.Services.Vendor.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class VendorController : ControllerBase
    { 

        private readonly ILogger<VendorController> _logger;
        private readonly IUnitOfWork _context;
        private readonly IMapper _mapper;

        public VendorController(ILogger<VendorController> logger,IUnitOfWork unitOfWork, IMapper mapper)
        {
            _logger = logger;
            _context = unitOfWork;
            _mapper = mapper; 
        }

        [HttpGet()]
         public async Task<SalesGoResponse> Get()
        {
            try
            {
                var dataGet = await _context.Vendor.WhereAsync(x => x.isActive == true);
                var mappedData = _mapper.Map<IEnumerable<VendorDTO>>(dataGet);

                return CustomRequest.CreateResponse(ApiResponseMessages.Retrieved, true, mappedData);

            }
            catch (Exception ex)
            {
                return CustomRequest.CreateResponse(ex.Message, false, null);
            }

        }

        [HttpGet("{Id}")]
        public async Task<SalesGoResponse> Get(string Id)
        {
            try
            {
                var dataGet = await _context.Vendor.FirstOrDefaultAsync(x => x.vendorId == Id);
                if (dataGet != null)
                {
                    var mappedData = _mapper.Map<VendorDTO>(dataGet);

                    return CustomRequest.CreateResponse(ApiResponseMessages.Retrieved, true, mappedData);

                }
                else
                    return CustomRequest.CreateResponse(ApiResponseMessages.NotFound, false, dataGet);


            }
            catch (Exception ex)
            {
                return CustomRequest.CreateResponse(ex.Message, false, null);
            }

        }

        [HttpGet("GetVendorsByBusinessId/{Id}")]
        public async Task<SalesGoResponse> GetVendorsByBusinessId(string Id)
        {
            try
            {
                var dataGet = await _context.Vendor.WhereAsync(x => x.businessId == Id && x.isActive == true);
                if (dataGet.Count()>0)
                {
                    var mappedData = _mapper.Map<IEnumerable<VendorDTO>>(dataGet);
                    return CustomRequest.CreateResponse(ApiResponseMessages.Retrieved, true, mappedData);

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
        public async Task<SalesGoResponse> CreateVendor(VendorDTO vendor)
        {
            try
            {

                if (vendor != null)
                {
                    vendor.vendorId = null;
                    var mappedData = _mapper.Map<Setup_Vendor>(vendor);
                    var response = await _context.Vendor.InsertAsync(mappedData);
                    if (response == true)
                    {
                        var _mappedData = _mapper.Map<VendorDTO>(vendor);

                        return CustomRequest.CreateResponse(ApiResponseMessages.Inserted, true, _mappedData);

                    }

                }

                return CustomRequest.CreateResponse(ApiResponseMessages.SomethingWentWrong, false, vendor);


            }
            catch (Exception ex)
            {
                return CustomRequest.CreateResponse(ex.Message, false, null);
            }
        }


        [HttpPut()]
        public async Task<SalesGoResponse> UpdateVendor(VendorDTO vendor)
        {
            try
            {
                if (vendor != null && !string.IsNullOrEmpty(vendor.vendorId))
                {
                    var existingCustomer = await _context.Vendor
                        .FirstOrDefaultAsync(x => x.isActive == true && x.vendorId == vendor.vendorId);

                    if (existingCustomer != null)
                    {
                        Type type = typeof(Setup_Vendor);
                        PropertyInfo[] properties = type.GetProperties();
                         

                        foreach (var property in properties)
                        {
                            // Check if the property is writable
                            if (property.CanWrite)
                            {
                                object valueFromObj2 = property.GetValue(vendor);
                                object valueFromObj1 = property.GetValue(existingCustomer);

                                // Only update if values are different
                                if (!object.Equals(valueFromObj1, valueFromObj2))
                                {
                                    if (valueFromObj2 != null)
                                    {
                                        property.SetValue(existingCustomer, valueFromObj2);
                                    }
                                }
                            }
                        }

                        var response = await _context.Vendor.UpdateAsync(existingCustomer, x => x.vendorId == vendor.vendorId);

                        if (response == true)
                        {
                            var _mappedData = _mapper.Map<VendorDTO>(existingCustomer);
                            return CustomRequest.CreateResponse(ApiResponseMessages.Updated, true, _mappedData);
                        }
                        else
                        {
                            // Handle the case when the update is not successful
                            return CustomRequest.CreateResponse(ApiResponseMessages.SomethingWentWrong, false, null);
                        }
                    }

                }

                return CustomRequest.CreateResponse(ApiResponseMessages.SomethingWentWrong, false, vendor);
            }
            catch (Exception ex)
            {
                return CustomRequest.CreateResponse(ex.Message, false, null);
            }
        }


        [HttpDelete()]
        public async Task<SalesGoResponse> Delete(string id)
        {
            try
            {
                if (!string.IsNullOrEmpty(id))
                {
                    var _Data = await _context.Vendor.FirstOrDefaultAsync(x => x.isActive == true && x.vendorId == id);
                    if (_Data != null)
                    {
                        _Data.isActive = false;
                        var response = await _context.Vendor.UpdateAsync(_Data, x => x.vendorId == id);
                        if (response == true)
                        {
                            var _mappedData = _mapper.Map<VendorDTO>(_Data);
                            return CustomRequest.CreateResponse(ApiResponseMessages.Deleted, true, _mappedData);

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
