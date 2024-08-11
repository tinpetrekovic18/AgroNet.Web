using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroNet.Model
{
    public class Usluga
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("VrstaUsluge")]
        public int VrstaUslugeId { get; set; }

        [Required]
        public string Naziv { get; set; }

        public string Opis { get; set; }

        public VrstaUsluge VrstaUsluge { get; set; }
    }

}
