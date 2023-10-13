using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UniversalCharger.Models;


namespace UniversalCharger.Data
{
    public class UniversalChargerContext : DbContext
    {
        public UniversalChargerContext(DbContextOptions<UniversalChargerContext> options)
                   : base(options)
        {
        }
        public DbSet<Charger> Charger { get; set; }
    }
}
