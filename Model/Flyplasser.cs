using HyperWing.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperWing.Model
{
    public class Flyplasser
    {
        [Key]
        public int FId { get; set; }
        public String Navn { get; set; }
        public virtual List<Reiser> Reiser { get; set; }
    }
}
