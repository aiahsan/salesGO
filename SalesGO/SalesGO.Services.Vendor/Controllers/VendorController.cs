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
using System.Linq;
using System.Numerics;
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
                var dataGet = await _context.Vendor.GetAll();
                var mappedData = _mapper.Map<IEnumerable<VendorDTO>>(dataGet);
                return CustomRequest.CreateResponse("", true, mappedData);

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
                var dataGet = await _context.Vendor.GetDataById(Id);
                var mappedData = _mapper.Map<VendorDTO>(dataGet);
                if(mappedData != null)
                {
                    return CustomRequest.CreateResponse("", true, mappedData);

                }
                else
                     return CustomRequest.CreateResponse("Vendor not found", false, mappedData);


            }
            catch (Exception ex)
            {
                return CustomRequest.CreateResponse(ex.Message, false, null);
            }



        }
        [HttpGet("/GetVendorByBusinessId/{Id}")]
        public async Task<SalesGoResponse> GetByBusiness(string Id)
        {
            try
            {
                var dataGet = await _context.Vendor.GetDataByBusinessId(Id);
                if(dataGet.Count()>0)
                {
                     var mappedData = _mapper.Map<IEnumerable<VendorDTO>>(dataGet);
                    if (mappedData != null)
                    {
                        return CustomRequest.CreateResponse("", true, mappedData);

                    }
                }
                
               
                    return CustomRequest.CreateResponse("Business not found", false, null);


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
             
                var mappedData = _mapper.Map<Setup_Vendor>(vendor);
                if (mappedData != null)
                {
                    mappedData.vendorId = null;
                    var response = await _context.Vendor.Create(mappedData);
                    if(response==true)
                    {
                        return CustomRequest.CreateResponse("", true, mappedData);

                    }

                }
            
                return CustomRequest.CreateResponse("Something wen't wrong", false, mappedData);


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
                var mappedData = _mapper.Map<Setup_Vendor>(vendor);
                if (mappedData != null)
                { 
                    var filter = Builders<Setup_Vendor>.Filter.Eq("vendorId", mappedData.vendorId);
                    var response = await _context.Vendor.Update(mappedData,filter);
                    if (response == true)
                    {
                        return CustomRequest.CreateResponse("Vendor Updated", true, mappedData);

                    }

                }

                return CustomRequest.CreateResponse("Something wen't wrong", false, mappedData);


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

                var filter = Builders<Setup_Vendor>.Filter.Eq("vendorId", id);
                var response = await _context.Vendor.Delete(filter);
                if (response == true)
                {
                   
                    return CustomRequest.CreateResponse("Vendor Updated", true, id);

                }

                return CustomRequest.CreateResponse("Something wen't wrong", false, null);


            }
            catch (Exception ex)
            {
                return CustomRequest.CreateResponse(ex.Message, false, null);
            }
        }

        [HttpPost("/Outlet")]
        public async Task<SalesGoResponse> CreateOutlet(VendorDTO vendor)
        {
            try
            {

                var mappedData = _mapper.Map<Setup_Vendor>(vendor);
                if (mappedData != null)
                {
                    mappedData.vendorId = null;
                    var response = await _context.Vendor.Create(mappedData);
                    if (response == true)
                    {
                        return CustomRequest.CreateResponse("", true, mappedData);

                    }

                }

                return CustomRequest.CreateResponse("Something wen't wrong", false, mappedData);


            }
            catch (Exception ex)
            {
                return CustomRequest.CreateResponse(ex.Message, false, null);
            }
        }

    }
}
