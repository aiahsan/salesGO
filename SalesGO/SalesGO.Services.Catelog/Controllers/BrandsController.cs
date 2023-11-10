using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Response.Const;
using SalesGO.Services.Catelog.Interfaces.IRepository;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using SalesGO.Services.Catelog.Model.DTOS;
using System.Linq;
using SalesGO.Services.Catelog.Model.Models;

namespace SalesGO.Services.Catelog.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {

        private readonly ILogger<BrandsController> _logger;
        private readonly IUnitOfWork _context;
        private readonly IMapper _mapper;

        public BrandsController(ILogger<BrandsController> logger, IUnitOfWork unitOfWork, IMapper mapper)
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
                var dataGet = await _context.BrandRepoObj.WhereAsync(x=>x.isActive==true);

                var mappedData = _mapper.Map<IEnumerable<BrandDTO>>(dataGet);
                return CustomRequest.CreateResponse("Brands retrieved successfully", true, mappedData);

            }
            catch (Exception ex)
            {
                return CustomRequest.CreateResponse(ex.Message, false, null);
            }
        }

        [HttpGet("{brandId}")]
        public async Task<SalesGoResponse> Get(int brandId)
        {
            try
            {
                var dataGet = await _context.BrandRepoObj.FirstOrDefaultAsync(x => x.isActive == true&&x.brandId==brandId);
                if(dataGet!=null)
                {
                    var mappedData = _mapper.Map<IEnumerable<BrandDTO>>(dataGet);
                    return CustomRequest.CreateResponse("Brands retrieved successfully", true, mappedData);
                }
                return CustomRequest.CreateResponse("Please input valid brand", false,null);


            }
            catch (Exception ex)
            {
                return CustomRequest.CreateResponse(ex.Message, false, null);
            }
        }

        [HttpGet("GetBrandByBusinessId/{businessId}")]
        public async Task<SalesGoResponse> GetBrandByBusinessId(string businessId)
        {
            try
            {
                var dataGet = await _context.BrandRepoObj.WhereAsync(x => x.isActive == true && x.businessId == businessId);
                if (dataGet.Count()>0)
                {
                    var mappedData = _mapper.Map<IEnumerable<BrandDTO>>(dataGet);
                    return CustomRequest.CreateResponse("Brands retrieved successfully", true, mappedData);
                }
                return CustomRequest.CreateResponse("No brands found for the provided business ID", false, null);


            }
            catch (Exception ex)
            {
                return CustomRequest.CreateResponse(ex.Message, false, null);
            }
        }

        [HttpPost()]
        public async Task<SalesGoResponse> Post(BrandDTO brand)
        {
            try
            {
                if(brand != null)
                {
                    var _brand = _mapper.Map<Brand>(brand);
                    var dataGet = await _context.BrandRepoObj.InsertAsync(_brand);
                    if(dataGet>0)
                    {
                        var _Mappedbrand = _mapper.Map<BrandDTO>(brand);

                        return CustomRequest.CreateResponse("Brands added successfully", true, _Mappedbrand);

                    }
                    return CustomRequest.CreateResponse("Something wen't wrong", false, brand);

                }
                else
                {
                    return CustomRequest.CreateResponse("Brand is empty", false, brand);

                }
               

            }
            catch (Exception ex)
            {
                return CustomRequest.CreateResponse(ex.Message, false, null);
            }
        } 
        [HttpPut()]
        public async Task<SalesGoResponse> Update(BrandDTO brand)
        {
            try
            {
                if (brand != null)
                {
                    var _brand=await _context.BrandRepoObj.FirstOrDefaultAsync(x=>x.brandId==brand.brandId);
                    if(_brand != null)
                    {
                        var _brandUpdate = _mapper.Map<Brand>(brand);
                        var dataGet = await _context.BrandRepoObj.UpdateAsync(_brandUpdate);
                       
                        if (dataGet == true)
                        { 
                            return CustomRequest.CreateResponse("Brands updated successfully", true, brand);

                        }
                    }
                  
                    return CustomRequest.CreateResponse("Something went wrong", false, brand);

                }
                else
                {
                    return CustomRequest.CreateResponse("Brand is empty", false, brand);

                }


            }
            catch (Exception ex)
            {
                return CustomRequest.CreateResponse(ex.Message, false, null);
            }
        }

        [HttpDelete]
        public async Task<SalesGoResponse> Delete(int brandId)
        {
            try
            {
                if (brandId >0)
                {
                    var _brand = await _context.BrandRepoObj.FirstOrDefaultAsync(x => x.brandId == brandId && x.isActive==true);
                    if (_brand != null)
                    {
                        _brand.isActive = false;
                        var dataGet = await _context.BrandRepoObj.UpdateAsync(_brand);
                         

                        if (dataGet == true)
                        {
                            var _mappedBrand = _mapper.Map<Brand>(_brand);

                            return CustomRequest.CreateResponse("Brand deleted successfully", true, _mappedBrand);

                        }
                    }

                    return CustomRequest.CreateResponse("Something went wrong", false, null);

                }
                else
                {
                    return CustomRequest.CreateResponse("Brand is empty", false, null);

                }


            }
            catch (Exception ex)
            {
                return CustomRequest.CreateResponse(ex.Message, false, null);
            }
        }

    }
}
