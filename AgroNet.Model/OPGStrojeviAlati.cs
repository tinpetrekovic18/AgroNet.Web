using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroNet.Model
{
    public class OPGStrojeviAlati
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("OPG")]
        public int OPGId { get; set; }

        [Required]
        [ForeignKey("StrojAlat")]
        public int StrojAlatId { get; set; }

        public OPG OPG { get; set; }
        public StrojAlat StrojAlat { get; set; }
    }

}
