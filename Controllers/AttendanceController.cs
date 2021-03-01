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



    [Route("api/[controller]/class")]
    public class AttendanceController : Controller
    {

        private readonly DBContext _context;

        public AttendanceController(DBContext context)
        {
            _context = context;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<AttendanceModel> Get()
        {
            return _context.attendance;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var person = _context.attendance.Where(ci => ci.lesson_id == id).ToArray();

            if (person == null)
            {
                return NotFound();
            }

            return Ok(person);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
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

    //by user
    [Route("api/[controller]/user")]
    public class UserAttendanceController : Controller
    {

        private readonly DBContext _context;

        public UserAttendanceController(DBContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var person = _context.attendance.Where(ci => ci.student_id == id).ToArray();

            if (person == null)
            {
                return NotFound();
            }

            return Ok(person);
        }


        

        [HttpPost]
        public async Task<ActionResult<AttendanceModel>> Post([FromBody]AttendanceModel am)
        {
            // _context.attendance.Add(am);
            await _context.attendance.AddAsync(am);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = am.id}, am);
        }
        
    }
}