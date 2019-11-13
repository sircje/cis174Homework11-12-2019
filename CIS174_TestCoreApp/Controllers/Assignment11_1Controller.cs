using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CIS174_TestCoreApp;
using CIS174_TestCoreApp.Models;
using CIS174_TestCoreApp.Filters;
using CIS174_TestCoreApp.Services;

namespace CIS174_TestCoreApp.Controllers
{

    [Route("api/Assignment11_1")]
    [FeatureEnabled(IsEnabled = true)] //feature toggle
    [ValidateModel]
    [HandleException]
    [LogResourceFilter]
    [ApiController]

    public class Assignment11_1Controller : ControllerBase
    {

        private readonly FamousPeopleService _service;

        public Assignment11_1Controller(FamousPeopleService service)
        {
            _service = service;
        }

        [EnsurePersonExists]
        [AddLastModifiedHeader]
        [Route("api/[controller]/{id:int}")]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var detail = _service.GetFamousPersonDetail(id);
            return Ok(detail);
        }

        
        [EnsurePersonExists]
        [Route("api/[controller]/{id:int}")]
        [HttpPost("{id}")]
        public IActionResult Edit(int id, [FromBody] UpdateFamousPeopleCommand command)
        {
            _service.UpdateFamousPeople(id, command);
            return Ok();
        }

        [Route("api/[controller]/create")]
        [HttpPost("api/Assignment11_1/create")]
        public IActionResult Add([FromBody]FamousPeople famousPeople)
        {
            return Ok();

        }

    }
}

/*This needs to work to copy how the instructor/book did it
 * 
 * 
 * [Route("api/[controller]")]
    [FeatureEnabled(IsEnabled = true)] //feature toggle
    [ValidateModel]
    [HandleException]
    [LogResourceFilter]
    [ApiController]
    
    public class Assignment11_1Controller : ControllerBase
    {

    private readonly FamousPeopleService _service;

        public Assignment11_1Controller(FamousPeopleService service)
        {
            _service = service;
        }

        [EnsurePersonExists]
        [AddLastModifiedHeader]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var detail = _service.GetPersonDetail(id);
            return Ok(detail);
        }
        [EnsurePersonExists]
        [HttpPost("{id}")]
        public IActionResult Edit (int id, [FromBody] UpdatePersonCommand command)
        {
            _service.UpdatePerson(id, command);
            return Ok();
        }

        // GET: api/Assignment11_1
        [AddLastModifiedHeader]
        [HttpGet]
        public IEnumerable<FamousPeople> GetFamousPeoples()
        {
            return _context.FamousPeoples;
        }

        // GET: api/Assignment11_1/5
        [AddLastModifiedHeader]
        [HttpGet("{id}")]
        [EnsurePersonExists]
        public async Task<IActionResult> GetFamousPeople([FromRoute] int id)
        {

            var famousPeople = await _context.FamousPeoples.FindAsync(id);

            return Ok(famousPeople);
        }
        }



    SAVE THIS FOR REFERENCE
    [Route("api/[controller]")]
    [FeatureEnabled(IsEnabled = true)] //feature toggle
    [ValidateModel]
    [HandleException]
    [LogResourceFilter]
    [ApiController]
    
    public class Assignment11_1Controller : ControllerBase
    {
        private readonly AppDbContext _context;

        public Assignment11_1Controller(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Assignment11_1
        [AddLastModifiedHeader]
        [HttpGet]
        public IEnumerable<FamousPeople> GetFamousPeoples()
        {
            return _context.FamousPeoples;
        }

        // GET: api/Assignment11_1/5
        [AddLastModifiedHeader]
        [HttpGet("{id}")]
        [EnsurePersonExists]
        public async Task<IActionResult> GetFamousPeople([FromRoute] int id)
        {

            var famousPeople = await _context.FamousPeoples.FindAsync(id);

            return Ok(famousPeople);
        }

        // PUT: api/Assignment11_1/5
        [HttpPut("{id}")]
        [EnsurePersonExists]
        public async Task<IActionResult> PutFamousPeople([FromRoute] int id, [FromBody] FamousPeople famousPeople)
        {
            if (id != famousPeople.FamousPeopleId)
            {
                return BadRequest();
            }

            _context.Entry(famousPeople).State = EntityState.Modified;


                await _context.SaveChangesAsync();
            

            return NoContent();
        }

        // POST: api/Assignment11_1
        [HttpPost]
        public async Task<IActionResult> PostFamousPeople([FromBody] FamousPeople famousPeople)
        {

            _context.FamousPeoples.Add(famousPeople);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFamousPeople", new { id = famousPeople.FamousPeopleId }, famousPeople);
        }

        // DELETE: api/Assignment11_1/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFamousPeople([FromRoute] int id)
        {


            var famousPeople = await _context.FamousPeoples.FindAsync(id);
            if (famousPeople == null)
            {
                return NotFound();
            }

            _context.FamousPeoples.Remove(famousPeople);
            await _context.SaveChangesAsync();

            return Ok(famousPeople);
        }

    }



*/
