using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperWing.Model
{
    public class Admin
    {
        [Required(ErrorMessage = "Navn må oppgis")]
        public String Navn { get; set; }
        [Required(ErrorMessage = "Passord må oppgis")]
        public String Passord { get; set; }
    }
}
