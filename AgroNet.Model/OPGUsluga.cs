using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroNet.Model
{
    public class OPGUsluga
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("OPG")]
        public int OPGId { get; set; }

        [Required]
        [ForeignKey("Usluga")]
        public int UslugaId { get; set; }

        public OPG OPG { get; set; }
        public Usluga Usluga { get; set; }
    }

}
