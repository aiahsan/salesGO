using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Response.Const;
using SalesGO.Services.Vendor.DataContext.Interfaces.IRepository;
using SalesGO.Services.Vendor.Model.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesGO.Services.Vendor.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IUnitOfWork _context;
        private readonly IMapper _mapper;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,IUnitOfWork unitOfWork, IMapper mapper)
        {
            _logger = logger;
            _context = unitOfWork;
            _mapper = mapper; 
        }

        [HttpGet]
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
    }
}
