using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tazer.Models;

namespace Tazer.Data
{
    public class TazerContext : DbContext
    {
        public TazerContext (DbContextOptions<TazerContext> options)
            : base(options)
        {
        }

        public DbSet<Tazer.Models.Tees> Tees { get; set; } = default!;
    }
}
