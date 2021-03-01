using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QueensGambit.Models
{
    public class BeltModel
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public int stripes { get; set; }
    }
}
