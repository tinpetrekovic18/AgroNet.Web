using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroNet.Model
{
    public class Vlasnik
    {
        [Key]
        public int Id { get; set; }

        [StringLength(11)]
        public string OIB { get; set; }

        [Required]
        [ForeignKey("Mjesto")]
        public int MjestoPrebivalistaId { get; set; }
        public Mjesto MjestoPrebivalista { get; set; }

        public string BrojTelefona { get; set; }

        public string Email { get; set; }

        
    }

}
