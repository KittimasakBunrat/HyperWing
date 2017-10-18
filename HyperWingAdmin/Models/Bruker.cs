using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace HyperWingAdmin.Models
{
    public class Bruker {
        public string Brukernavn { get; set; }
        public string Passord { get; set; }
    }

    public class dbBruker {

        [Key]
        public string Brukernavn { get; set; }
        public byte[] Passord { get; set; }
        public string Salt { get; set; }
    }

    public class BrukerContext : DbContext {

        public BrukerContext()
        : base("name=Bruker") {
            Database.CreateIfNotExists();
        }

        public DbSet<dbBruker> Brukere { get; set; }

        }

    }
        