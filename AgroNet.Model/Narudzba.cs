using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroNet.Model
{
    public class Narudzba
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("KupacOPG")]
        public int KupacOPGId { get; set; }

        [Required]
        [ForeignKey("ProdavacOPG")]
        public int ProdavacOPGId { get; set; }

        public DateTime? DatumNarudzbe { get; set; }
        public DateTime? DatumIsporuke { get; set; }

        [Required]
        [ForeignKey("StatusNarudzbe")]
        public int StatusNarudzbeId { get; set; }

        public OPG KupacOPG { get; set; }
        public OPG ProdavacOPG { get; set; }
        public StatusNarudzbe StatusNarudzbe { get; set; }
    }

}
