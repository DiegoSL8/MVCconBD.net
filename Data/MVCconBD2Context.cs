using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVCconBD2.Models;

namespace MVCconBD2.Data
{
    public class MVCconBD2Context : DbContext
    {
        public MVCconBD2Context (DbContextOptions<MVCconBD2Context> options)
            : base(options)
        {
        }

        public DbSet<MVCconBD2.Models.Pelicula> Pelicula { get; set; } = default!;
    }
}
