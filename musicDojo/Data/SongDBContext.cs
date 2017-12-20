using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using musicDojo.Models;

namespace musicDojo.Data
{
    public class SongDBContext : DbContext
    {
        public SongDBContext(DbContextOptions<SongDBContext> options)
            : base(options)
        {

        }

        public DbSet<Song> Song { get; set; }
    }
}
