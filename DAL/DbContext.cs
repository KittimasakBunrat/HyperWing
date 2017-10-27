using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration.Conventions;
using HyperWing.Model;

namespace HyperWing.DAL
{

    public class dbAdmin
    {
        [Key]
        public String Navn { get; set; }
        public byte[] Passord { get; set; }
        public String Salt { get; set; }
    }
    /*
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
        */

    public class FlyContext : DbContext
    {
        public FlyContext() : base("name=HyperWing")
        {
            Database.SetInitializer(new DbInit());
            Database.Initialize(true);
        }

        public DbSet<dbAdmin> Administratorer { get; set; }
        public DbSet<Flyplasser> Flyplasser { get; set; }
        public DbSet<Reiser> Reiser { get; set; }

        //lag entiter, fjern import
        public DbSet<Kunde> Kunder { get; set; }
        //lag entiter, fjern import 
        public DbSet<Billett> Billetter { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
