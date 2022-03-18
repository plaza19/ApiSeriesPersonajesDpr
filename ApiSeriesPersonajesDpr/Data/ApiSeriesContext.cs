using ApiSeriesPersonajesDpr.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiSeriesPersonajesDpr.Data
{
    public class ApiSeriesContext : DbContext
    {

        public ApiSeriesContext(DbContextOptions<ApiSeriesContext> options) : base(options)
        {

        }

        public DbSet<Serie> Series { get; set; }
        public DbSet<Personaje> Personajes { get; set; }

    }
}
