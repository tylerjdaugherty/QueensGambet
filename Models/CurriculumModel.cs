using System;

using System.ComponentModel.DataAnnotations;

namespace QueensGambit.Models
{
    public class CurriculumModel
    {
        public CurriculumModel() { }

        [Key]
        public int id { get; set; }
        public string name { get; set; }
    }
}
