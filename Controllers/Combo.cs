using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QueensGambit.DAL;
using QueensGambit.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QueensGambit.Controllers
{
    

    [Route("api/[controller]")]
    public class Combo : Controller
    {
        private readonly DBContext _context;

        public Combo(DBContext context)
        {
            _context = context;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<CurriculumModel> Get()
        {
            return _context.curriculum;
        }
    }
}
