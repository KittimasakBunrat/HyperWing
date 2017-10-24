using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperWing.Model
{
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
}
