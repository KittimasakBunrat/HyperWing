using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HyperWing.Models
{
    public class Billett
    {
        //billettene skal ikke lagres i database
        [Key]
        public int Id { get; set; }
        public String PersonNr { get; set; }
        public String Navn { get; set; }
        public String ByFra { get; set; }
        public String Mellomlanding { get; set; }
        public String ByTil { get; set; }
        public String Epost { get; set; }
        public int Telefon { get; set; }
        public DateTime Avgang { get; set; }
        public DateTime Ankomst { get; set; }
        public String Flyplass { get; set; }
        public double Pris { get; set; }
    } 
}