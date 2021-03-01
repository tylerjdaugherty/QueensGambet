using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QueensGambit.Models
{
    public class AttendanceModel
    {
        [Key]
        public int id { get; set; }
        public int lesson_id { get; set; }
        public int student_id { get; set; }

        public AttendanceModel(int li, int si)
        {
            this.lesson_id = li;
            this.student_id = si;
        }

        public AttendanceModel(int id, int li, int si)
        {
            this.id = id; 
            this.lesson_id = li;
            this.student_id = si;
        }

        public AttendanceModel() { }

    }

    
}
