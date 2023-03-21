using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsButikMedEF
{
    public class Model : DbContext
    {
        public DbSet<Vare> Varer { get; set; }
        public DbSet<Bestilling> Bestillinger { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=IsButikMedEF; Trusted_Connection = True; ");
        }
    }
    public class Vare
    {
        public int Id { get; set; }
        public string Navn { get; set; }
        public string Beskrivelse { get; set; }
        public double Pris { get; set; }
        public List<Bestilling> Bestillinger { get; set; }
    }
    public class Bestilling
    {
        public int Id { get; set; }
        public int Antal { get; set; }
        public Vare Vare { get; set; }
        public string Bemærkninger { get; set; }
    }
}
