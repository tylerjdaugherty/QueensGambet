using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QueensGambit.DAL;
using QueensGambit.Models;

namespace QueensGambit.Controllers
{
    [Route("api/[controller]")]
    public class CurriculumController : Controller
    {
        private readonly DBContext _context;

        public CurriculumController(DBContext context)
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
