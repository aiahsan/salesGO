using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using Response.Const;
using SalesGO.Services.Customer.DataContext.Interfaces.IRepository;
using SalesGO.Services.Customer.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
                var dataGet = await _context.Customer.GetAll();
                 return CustomRequest.CreateResponse("", true, dataGet);

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
                var dataGet = await _context.Customer.GetDataById(Id);
                 if (dataGet != null)
                {
                    return CustomRequest.CreateResponse("", true, dataGet);

                }
                else
                    return CustomRequest.CreateResponse("Customer not found", false, dataGet);


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
                var dataGet = await _context.Customer.GetDataByBusinessId(Id);
                if (dataGet != null)
                {
                    return CustomRequest.CreateResponse("", true, dataGet);

                }
                else
                    return CustomRequest.CreateResponse("Customers not found", false, dataGet);


            }
            catch (Exception ex)
            {
                return CustomRequest.CreateResponse(ex.Message, false, null);
            }

        }

        [HttpPost()]
        public async Task<SalesGoResponse> CreateVendor(Setup_Customer customer)
        {
            try
            {

                 if (customer != null)
                {
                    customer.customerId = null;
                    var response = await _context.Customer.Create(customer);
                    if (response == true)
                    {
                        return CustomRequest.CreateResponse("", true, customer);

                    }

                }

                return CustomRequest.CreateResponse("Something wen't wrong", false, customer);


            }
            catch (Exception ex)
            {
                return CustomRequest.CreateResponse(ex.Message, false, null);
            }
        }


        [HttpPut()]
        public async Task<SalesGoResponse> UpdateVendor(Setup_Customer customer)
        {
            try
            {
                 if (customer != null)
                {
                    var filter = Builders<Setup_Customer>.Filter.Eq("customerId", customer.customerId);
                    var response = await _context.Customer.Update(customer, filter);
                    if (response == true)
                    {
                        return CustomRequest.CreateResponse("Vendor Updated", true, customer);

                    }

                }

                return CustomRequest.CreateResponse("Something wen't wrong", false, customer);


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

                var filter = Builders<Setup_Customer>.Filter.Eq("customerId", id);
                var response = await _context.Customer.Delete(filter);
                if (response == true)
                {

                    return CustomRequest.CreateResponse("Customer Updated", true, id);

                }

                return CustomRequest.CreateResponse("Something wen't wrong", false, null);


            }
            catch (Exception ex)
            {
                return CustomRequest.CreateResponse(ex.Message, false, null);
            }
        }
    }
}
