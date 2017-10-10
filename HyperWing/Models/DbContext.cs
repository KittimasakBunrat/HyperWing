using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.ComponentModel.DataAnnotations;

namespace HyperWing.Models
{

    public class Flyplasser
    {
        [Key]
        public int FId { get; set; }
        public String Navn { get; set; }
        public virtual List<Reiser> Reiser { get; set; }
    }

    public class Reiser
    {
        [Key]
        public int RId { get; set; }
        public String ByFra { get; set; }
        public String ByTil { get; set; }
        public String Flyplass { get; set; }
        public DateTime Avgangstid { get; set; }
        public DateTime Ankomstid { get; set; }
        public String Reisetid { get; set; }
        public double Pris { get; set; }
        public String Informasjon { get; set; }
        public int FId { get; set; }

    }

    public class FlyContext : DbContext
    {
        public FlyContext() : base("name=HyperWing")
        {
            Database.CreateIfNotExists();
            Database.SetInitializer(new DbInit());
        }

        public DbSet<Flyplasser> Flyplasser { get; set; }
        public DbSet<Reiser> Reiser { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}