using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using QueensGambit.Models;

namespace QueensGambit.DAL
{
    public class DBContext : DbContext
    {
        public DbSet<PersonModel> person { get; set; }
        public DbSet<AttendanceModel> attendance { get; set; }
        public DbSet<BeltModel> belt { get; set; }
        public DbSet<LessonModel> lesson { get; set; }
        public DbSet<CurriculumModel> curriculum { get; set; }

        public DBContext():base()
        {

        }

        public DBContext(DbContextOptions options) : base(options)
        {

        }
    }
}
