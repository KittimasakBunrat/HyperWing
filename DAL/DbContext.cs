using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration.Conventions;
using HyperWing.Model;
using System.IO;
using Model;

namespace HyperWing.DAL
{

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
        public DbSet<Kunde> Kunder { get; set; }
        public DbSet<Billett> Billetter { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public void LoggEndringer(String param)
        {

            String path = System.AppDomain.CurrentDomain.BaseDirectory + "/Endringer_Logg.txt";
            File.AppendAllText(path, param);
        }

        public void LoggFeilmeldinger(String param)
        {
            String path = System.AppDomain.CurrentDomain.BaseDirectory + "/Feil_Logg";
            File.AppendAllText(path, param); 
        }
    }
}
