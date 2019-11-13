using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CIS174_TestCoreApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CIS174_TestCoreApp.Controllers
{
    
    [ApiController]
    public class HouseController : ControllerBase
    {
        List<HouseViewModel> _houses = new List<HouseViewModel>() {
                new HouseViewModel() { bedrooms = 4, sqaureFeet = 1854, dateBuilt = "05/28/1973", flooring = "Carpet" } ,
                new HouseViewModel() { bedrooms = 3, sqaureFeet = 1675, dateBuilt = "10/17/2015", flooring = "Hardwood" }
            };
        // GET: api/House
        [Route("api/[controller]")]
        [HttpGet]
        public IEnumerable<HouseViewModel> Houses()
        {

            return _houses;
        }
        [Route("api/[controller]/{id:int}")]
        // GET: api/House/int
        [HttpGet]
        public IActionResult Get(int id)
        {
            id--;
            if (id >= 0 && id < _houses.Count)
            {
                return Ok(_houses[id]);
            }
            return NotFound();
        }
        [Route("api/[controller]/create")]
        // POST: api/House/create
        [HttpPost("api/house/create")]
        public IActionResult Add([FromBody]HouseViewModel model)
        {
            return Ok();

        }
        [Route("api/[controller]/{id:int}")]
        // PUT: api/House/int
        [HttpPut]
        public void Put(int id, [FromBody] string value)
        {
        }
        [Route("api/[controller]/{id:int}")]
        // DELETE: api/ApiWithActions/5
        [HttpDelete]
        public void Delete(int id)
        {
        }
    }
}
