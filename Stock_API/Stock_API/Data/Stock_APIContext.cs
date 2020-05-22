using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Stock_API.Entities;

namespace Stock_API.Models
{
    public class Stock_APIContext : DbContext
    {
        public Stock_APIContext (DbContextOptions<Stock_APIContext> options)
            : base(options)
        {
        }

        public DbSet<ProftCenter> ProftCenter { get; set; }

        public DbSet<Stock> stock { get; set; }
    }
}
