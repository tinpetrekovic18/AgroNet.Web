using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroNet.Model
{
    public class VlasnikOPG
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Vlasnik")]
        public int VlasnikId { get; set; }

        [Required]
        [ForeignKey("OPG")]
        public int OPGId { get; set; }

        public Vlasnik Vlasnik { get; set; }
        public OPG OPG { get; set; }
    }

}
