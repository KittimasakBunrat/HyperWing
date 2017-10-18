using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace HyperWing.DAL
{

    public class dbAdmin
    {
        [Key]
        public String Navn { get; set; }
        public byte[] Passord { get; set; }
        public String Salt { get; set; }
    }

    public class Dbinit : DropCreateDatabaseAlways<AdminContext>
    {
        protected override void Seed(AdminContext context)
        {
            var db = new DB();

            String passord = "root"; 
            String salt = db.lagSalt();
            var passordOgSalt = passord + salt;
            byte[] passordDB = db.lagHash(passordOgSalt);

            var admin1 = new dbAdmin()
            {
                Navn = "root",
                Salt = salt,
                Passord = passordDB
            };

            context.Administratorer.Add(admin1);

            base.Seed(context);
        }
    }

    public class AdminContext : DbContext
    {
        public AdminContext() : base("name=Admin")
        {
            Database.CreateIfNotExists();
        }

        public DbSet<dbAdmin> Administratorer { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
