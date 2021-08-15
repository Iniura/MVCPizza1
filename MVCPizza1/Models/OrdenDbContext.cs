using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCPizza1.Models
{
    public class OrdenDbContext : DbContext
    {
        public DbSet<Orden> Ordenes { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Ordenes.db");
        }


    }
}
