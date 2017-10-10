using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HyperWing.Models
{
    public class Kunde
    {
        public int Id;

        [Display(Name ="Person Nummer")]
        [Required(ErrorMessage ="Oppgi Person nummer")]
        public int personNr { get; set; }

        [Display(Name ="Navn")]
        [Required(ErrorMessage ="Oppgi Navn")]
        public String navn { get; set; }

        [Display(Name ="Epost Adresse")]
        [EmailAddress(ErrorMessage ="Oppgi gyldig Epost")]
        public String epost { get; set; }

        [Display(Name ="Telefon Nummer")]
        [Required(ErrorMessage ="Oppgi Telefon nummer")]
        public int telefon { get; set; }
    }
}