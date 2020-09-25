using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Building.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Building.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReadingController : ControllerBase
    {
        private readonly IReading _reading;
        public ReadingController(IReading reading)
        {
            _reading = reading;
        }
        // GET api/reading
        [Route("atik/{buildingId}/{objectId}/{datafieldId}/{fromDate}/{toDate}")]
        [HttpGet]
        //int buildingId, int objectId , int datafieldId,string fromDate, string toDate
        public ActionResult<IEnumerable<string>> Get(int buildingId, int objectId, int datafieldId, string fromDate, string toDate)
        {
            //new string[] { "value1", "value2" };
            //return null;
            return Ok(_reading.GetReadingsData(buildingId, objectId, datafieldId, fromDate, toDate));
        }
    }
}