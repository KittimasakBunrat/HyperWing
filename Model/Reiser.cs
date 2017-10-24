using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Reiser
    {
        public int Id { get; set; }
        public String ByFra { get; set; }
        public String ByTil { get; set; }
        public String Flyplass { get; set; }
        public DateTime Avgangstid { get; set; }
        public DateTime Ankomstid { get; set; }
        public String Reisetid { get; set; }
        public double Pris { get; set; }
        public String Informasjon { get; set; }
    }
}
