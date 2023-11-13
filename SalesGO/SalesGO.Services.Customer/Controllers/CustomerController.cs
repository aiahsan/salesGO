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

namespace SalesGO.Services.Customer.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly IUnitOfWork _context;


        public CustomerController(ILogger<CustomerController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _context = unitOfWork;

        }

        [HttpGet()]
        public async Task<SalesGoResponse> Get()
        {
            try
            {
                var dataGet = await _context.Customer.WhereAsync(x=>x.isActive==true);
                 return CustomRequest.CreateResponse(ApiResponseMessages.Retrieved, true, dataGet);

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
                var dataGet = await _context.Customer.FirstOrDefaultAsync(x=>x.customerId==Id);
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

        [HttpGet("GetCustomersByBusinessId/{Id}")]
        public async Task<SalesGoResponse> GetCustomersByBusinessId(string Id)
        {
            try
            {
                var dataGet = await _context.Customer.WhereAsync(x=>x.businessId==Id && x.isActive==true);
                if (dataGet .Count()>0)
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
        public async Task<SalesGoResponse> CreateCustomer(Setup_Customer customer)
        {
            try
            {

                 if (customer != null)
                {
                    customer.customerId = null;
                    var response = await _context.Customer.InsertAsync(customer);
                    if (response == true)
                    {
                        return CustomRequest.CreateResponse(ApiResponseMessages.Inserted, true, customer);

                    }

                }

                return CustomRequest.CreateResponse(ApiResponseMessages.SomethingWentWrong, false, customer);


            }
            catch (Exception ex)
            {
                return CustomRequest.CreateResponse(ex.Message, false, null);
            }
        } 
        [HttpPut()]
        public async Task<SalesGoResponse> UpdateCustomer(Setup_Customer customer)
        {
            try
            {
                if (customer != null && !string.IsNullOrEmpty(customer.customerId))
                {
                    var existingCustomer = await _context.Customer
                        .FirstOrDefaultAsync(x => x.isActive == true && x.customerId == customer.customerId);

                    if (existingCustomer != null)
                    {
                        Type type = typeof(Setup_Customer);
                        PropertyInfo[] properties = type.GetProperties();

                        // Setting outlets from db to the main customer so it won't override it
                        customer.Outlets = existingCustomer.Outlets;

                        foreach (var property in properties)
                        {
                            // Check if the property is writable
                            if (property.CanWrite)
                            {
                                object valueFromObj2 = property.GetValue(customer);
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

                        var response = await _context.Customer.UpdateAsync(existingCustomer, x => x.customerId == customer.customerId);

                        if (response == true)
                        {
                            return CustomRequest.CreateResponse(ApiResponseMessages.Updated, true, existingCustomer);
                        }
                        else
                        {
                            // Handle the case when the update is not successful
                            return CustomRequest.CreateResponse(ApiResponseMessages.SomethingWentWrong, false, null);
                        }
                    }
                   
                }

                return CustomRequest.CreateResponse(ApiResponseMessages.SomethingWentWrong, false, customer);
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
                    var _Data = await _context.Customer.FirstOrDefaultAsync(x => x.isActive == true && x.customerId == id);
                    if (_Data != null)
                    {
                        _Data.isActive = false;
                        var response = await _context.Customer.UpdateAsync(_Data, x => x.customerId == id);
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
