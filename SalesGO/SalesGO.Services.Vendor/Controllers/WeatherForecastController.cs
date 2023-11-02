using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        public async Task<IEnumerable<WeatherForecast>> Get()
        {

            var dataGet=await _context.Vendor.GetAll();
            var mappedData=  _mapper.Map<IEnumerable<VendorDTO>>(dataGet);

            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
