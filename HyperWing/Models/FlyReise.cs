using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Text;

namespace HyperWing.Models
{
    public class FlyReise
    {
        public int Id { get; set; }

        [DisplayName("Flyplass")]
        public String flyplass { get; set; }

        [DisplayName("Fra")]
        public String byFra { get; set; }

        [DisplayName("Til")]
        public String byTil { get; set; }

        [DisplayName("Avgang")]
        public DateTime avgangstid { get; set; }

        [DisplayName("Ankomst")]
        public DateTime ankomstid { get; set; }

        [DisplayName("Reisetid")]
        public String reisetid { get; set; }
  
        [DisplayName("Pris (NOK)")]
        public double pris { get; set; }

        [DisplayName("Flyrute")]
        public String informasjon { get; set; }
    }

}