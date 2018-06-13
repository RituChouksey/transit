using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Model;
using Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Produces("application/json")]
    [Route("")]
    public class DistanceController : Controller
    {
        StationsService stationcService;
        public DistanceController(IStationsService service)
        {
            this.stationcService = (StationsService)service;
        }
        // GET api/<controller>
        //[HttpGet("{start/end}")]
        [Route("api/[controller]")]
        public Double Get(String start, String end)
        {
            return stationcService.getDistanceBetweenStations(start, end);
        }
    }
}