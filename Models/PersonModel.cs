﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace QueensGambit.Models
{
    public class PersonModel
    {
        [Key]
        public int id { get; set; }
        public string last_name { get; set; }
        public string first_name { get; set; }
        public int? belt { get; set; }
        public byte[]? waiver { get; set; }
        public bool? instructor { get; set; } = false;
        public byte[]? profile_pic { get; set; }
        public int? class_count { get; set; }
        public string phone_number { get; set; }
        public string emergency_contact { get; set; }
        public string ec_phone { get; set; }

    }
}
