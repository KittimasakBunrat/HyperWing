using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class dbAdmin
    {
        [Key]
        public String Navn { get; set; }
        public byte[] Passord { get; set; }
        public String Salt { get; set; }
    }
}
