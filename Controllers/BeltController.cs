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
    public class BeltController : Controller
    {

        private readonly DBContext _context;

        public BeltController(DBContext context)
        {
            _context = context;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<BeltModel> Get()
        {
            return _context.belt;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var belt = await _context.belt.FindAsync(id);

            if (belt == null)
            {
                return NotFound();
            }

            return Ok(belt);
        }

    }
}
