using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroNet.Model
{
    public class OPG
    {
        [Key]
        public int Id { get; set; }

        public string Naziv { get; set; }

        public string Adresa { get; set; }

        public string IBAN { get; set; }

        [Required]
        [ForeignKey("Mjesto")]
        public int MjestoId { get; set; }

        public Mjesto Mjesto { get; set; }
    }

}