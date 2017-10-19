using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
namespace HyperWingAdmin.Models
{
    public class admin
    {
        [Required(ErrorMessage= "ID måste skrivas in")]

        public string Brukernavn { get; set; }
        [Required(ErrorMessage = "Lösenord måste skrivas in")]
        public string Passord { get; set; }
    }

    public class dbAdmin
    {
        [Key]
        public string Brukernavn { get; set; }
        public byte[] Passord { get; set; }
        public byte[] Salt { get; set; }
    }

    public class AdminContext : DbContext
    {
        public AdminContext() 
            : base("name=Admin")
        {
            Database.CreateIfNotExists();
        }

        public DbSet<dbAdmin> Admins { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}