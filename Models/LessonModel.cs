using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QueensGambit.Models
{
    public class LessonModel
    {
        [Key]
        public int lesson_id { get; set; }
        public string date { get; set; }
        public int? curriculum_id { get; set; }
        public int? curriculum1_id { get; set; }
        public int? curriculum2_id { get; set; }
        public int? technique_id { get; set; }
        public int? technique1_id { get; set; }
        public int? technique2_id { get; set; }
        public int? technique3_id { get; set; }
        public int? technique4_id { get; set; }
        public int? technique5_id { get; set; }
        
    }
}
