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
    [Route("api/[controller]")]
    public class LessonController : Controller
    {
        private readonly DBContext _context;

        public LessonController(DBContext context)
        {
            _context = context;
        }


        // GET: api/values
        [HttpGet]
        public IEnumerable<LessonModel> Get()
        {
            return _context.lesson;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var lesson = await _context.lesson.FindAsync(id);

            if (lesson == null)
            {
                return NotFound();
            }

            return Ok(lesson);
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult<AttendanceModel>> Post([FromBody] LessonModel lm)
        {
            // _context.attendance.Add(am);
            await _context.lesson.AddAsync(lm);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = lm.lesson_id }, lm);
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

    [Route("api/[controller]/latest")]
    public class CurrentLessonController : Controller
    {
        private readonly DBContext _context;

        public CurrentLessonController(DBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public LessonModel Get()
        {
            return _context.lesson.OrderBy(l => l.lesson_id).LastOrDefault();
        }

    }

}
