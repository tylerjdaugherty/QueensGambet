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

    public class LessonCountController : Controller
    {
        private readonly DBContext _context;

        public LessonCountController(DBContext context)
        {
            _context = context;
        }


        // GET: api/values
        //id is student id
        [HttpGet("{id}")]
        public List<LessonCounter> Get([FromRoute] int id)
        {
            List<LessonCounter> counter = new List<LessonCounter>();
            var classes = _context.attendance.Where(
                s => s.student_id == id);
            foreach (var c in classes)
            {
                LessonCounter.class_count++;

                var lc = new LessonCounter();

                var lesson = _context.lesson.Where(l => l.lesson_id == c.lesson_id).FirstOrDefault();
                var cur = _context.curriculum.Where(c => c.id == lesson.curriculum_id).FirstOrDefault();
                try
                {
                    lc.class_id = lesson.lesson_id;
                    lc.curriculum = cur.name;

                    if (lesson.curriculum2_id > 0)
                    {
                        var curriculum1 = _context.curriculum.Where(c => c.id == lesson.curriculum1_id).FirstOrDefault();
                        lc.curriculum1 = curriculum1.name;

                    }

                    if (lesson.curriculum2_id > 0)
                    {
                        var curriculum2 = _context.curriculum.Where(c => c.id == lesson.curriculum1_id).FirstOrDefault();
                        lc.curriculum2 = curriculum2.name;
                    }

                    counter.Add(lc);

                }
                catch (NullReferenceException nre) {  }  
            }
            return counter;
        }

    }
}