using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroNet.Model
{
    public class DjelatnostiOPG
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("OPG")]
        public int OPGId { get; set; }

        [Required]
        [ForeignKey("Djelatnost")]
        public int DjelatnostId { get; set; }

        public OPG OPG { get; set; }
        public Djelatnost Djelatnost { get; set; }
    }

}
