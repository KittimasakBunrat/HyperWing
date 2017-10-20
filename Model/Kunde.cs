using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HyperWing.Model
{
    public class Kunde
    {
        [Key]
        public int Id { get; set; }

        [Display(Name ="Person Nummer")]
        [Required(ErrorMessage ="Oppgi Person nummer")]
        public String personNr { get; set; }

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