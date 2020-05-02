using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MvcFeeder.Models
{
    public class MvcFeederContext : DbContext
    {
        public MvcFeederContext (DbContextOptions<MvcFeederContext> options)
            : base(options)
        {
        }

        public DbSet<MvcFeeder.Models.BreastFeed> BreastFeed { get; set; }
    }
}
