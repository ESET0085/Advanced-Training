using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KuchBhi.Model;

namespace KuchBhi.Data
{
    public class KuchBhiContext : DbContext
    {
        public KuchBhiContext (DbContextOptions<KuchBhiContext> options)
            : base(options)
        {
        }

        public DbSet<KuchBhi.Model.Student> Student { get; set; } = default!;
    }
}
