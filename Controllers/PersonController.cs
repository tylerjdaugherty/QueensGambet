using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QueensGambit.DAL;
using QueensGambit.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QueensGambit.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly DBContext _context;

        public PersonController(DBContext context)
        {
            _context = context;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<PersonModel> Get()
        {
            return _context.person;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var person = await _context.person.FindAsync(id);

            if (person == null)
            {
                return NotFound();
            }

            return Ok(person);
        }

        
        [HttpPost]
        public async Task<ActionResult<AttendanceModel>> Post([FromBody] PersonModel pm)
        {
            // _context.attendance.Add(am);
            await _context.person.AddAsync(pm);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = pm.id }, pm);
        }
        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
