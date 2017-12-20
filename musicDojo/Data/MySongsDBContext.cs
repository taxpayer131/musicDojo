using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using musicDojo.Models;

namespace musicDojo.Data
{
    public class MySongsDBContext:DbContext
    {
        public MySongsDBContext(DbContextOptions<MySongsDBContext> options)
            : base(options)
        {

        }

        public DbSet<MySongs> MySongs { get; set; }
    }
}
