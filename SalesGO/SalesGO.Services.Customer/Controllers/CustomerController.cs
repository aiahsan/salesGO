using AutoMapper;
using Const;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using Response.Const;
using SalesGO.Services.Customer.DataContext.Interfaces.IRepository;
using SalesGO.Services.Customer.Model.DTOS;
using SalesGO.Services.Customer.Model.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
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
        private readonly IMapper _mapper;

        public CustomerController(ILogger<CustomerController> logger, IUnitOfWork unitOfWork, IMapper mapper)
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
                

                var dataGet = await _context._CustoemrRepo.WhereAsync(x => x.isActive == true);
                var mappedData = _mapper.Map<IEnumerable<CustomerDTO>>(dataGet);
                return CustomRequest.CreateResponse(ApiResponseMessages.Retrieved, true, mappedData);

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
                var dataGet = await _context._CustoemrRepo.FirstOrDefaultAsync(x=>x.customerId==Id);
                 if (dataGet != null)
                {
                    var mappedData = _mapper.Map<CustomerDTO>(dataGet);
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

        [HttpGet("GetCustomersByBusinessId/{Id}")]
        public async Task<SalesGoResponse> GetCustomersByBusinessId(string Id)
        {
            try
            {
                var dataGet = await _context._CustoemrRepo.WhereAsync(x=>x.businessId==Id && x.isActive==true);
                if (dataGet .Count()>0)
                {
                    var mappedData = _mapper.Map<IEnumerable<CustomerDTO>>(dataGet);
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

        [HttpGet("Filter")]
        public async Task<SalesGoResponse> Filter(string businessName,string telephone,string contact,string email,string representativeName,string representativeDesignation,string address,int page=1,int limit=1)
        {
            try
            {
              

                var predicate = PredicateBuilder.True<Setup_Customer>();

                if (!string.IsNullOrEmpty(businessName))
                    predicate = predicate.And(x => x.customerBusinessName.ToLower().Contains(businessName.ToLower()) );

                if (!string.IsNullOrEmpty(telephone))
                    predicate = predicate.And(x => x.customerTelephone.ToLower().Contains(telephone.ToLower()));

                if (!string.IsNullOrEmpty(contact))
                    predicate = predicate.And(x => x.customerContact.ToLower().Contains(contact.ToLower()));

                if (!string.IsNullOrEmpty(email))
                    predicate = predicate.And(x => x.customerEmail.ToLower().Contains(email.ToLower()));

                if (!string.IsNullOrEmpty(representativeName))
                    predicate = predicate.And(x => x.customerRepresentativeName.ToLower().Contains(representativeName.ToLower()));

                if (!string.IsNullOrEmpty(representativeDesignation))
                    predicate = predicate.And(x => x.customerRepresentativeDesignation.ToLower().Contains(representativeDesignation.ToLower()));

                if (!string.IsNullOrEmpty(address))
                    predicate = predicate.And(x => x.customerAddress.ToLower().Contains(address.ToLower()));

                    
                    predicate = predicate.And(x => x.isActive == true);
                

                




                var dataGet = await  _context._CustoemrRepo.BatchFiltersync(predicate, page,limit);

                var mappedData = _mapper.Map<IEnumerable<CustomerDTO>>(dataGet);

                return CustomRequest.CreateResponse(ApiResponseMessages.Retrieved, true, mappedData);
            }
            catch (Exception ex)
            {
                return CustomRequest.CreateResponse(ex.Message, false, null);
            }


        }

        [HttpPost()]
        public async Task<SalesGoResponse> CreateCustomer(CustomerDTO customer)
        {
            try
            {

                 if (customer != null)
                {
                    var mappedData = _mapper.Map<Setup_Customer>(customer);
                    var response = await _context._CustoemrRepo.InsertAsync(mappedData);
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
        public async Task<SalesGoResponse> UpdateCustomer(CustomerDTO customer)
        {
            try
            {
                if (customer != null && customer.customerId>0)
                {
                    var existingCustomer = await _context._CustoemrRepo
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

                        var response = await _context._CustoemrRepo.UpdateAsync(existingCustomer, x => x.customerId == customer.customerId);

                        if (response == true)
                        {

                            var mappedData = _mapper.Map<CustomerDTO>(existingCustomer);

                            return CustomRequest.CreateResponse(ApiResponseMessages.Updated, true, mappedData);
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
        public async Task<SalesGoResponse> Delete(int id)
        {
            try
            {
                if (id!=null)
                {
                    var _Data = await _context._CustoemrRepo.FirstOrDefaultAsync(x => x.isActive == true && x.customerId == id);
                    if (_Data != null)
                    {
                        _Data.isActive = false;
                        var response = await _context._CustoemrRepo.UpdateAsync(_Data, x => x.customerId == id);
                        if (response == true)
                        {
                            var mappedData = _mapper.Map<CustomerDTO>(_Data);

                            return CustomRequest.CreateResponse(ApiResponseMessages.Deleted, true, mappedData);

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
