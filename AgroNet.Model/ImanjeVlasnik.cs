using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroNet.Model
{
    public class ImanjeVlasnik
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Vlasnik")]
        public int VlasnikId { get; set; }

        [Required]
        [ForeignKey("Imanje")]
        public int ImanjeId { get; set; }

        [Required]
        [ForeignKey("Proizvod")]
        public int ProizvodId { get; set; }

        public Vlasnik Vlasnik { get; set; }
        public Imanje Imanje { get; set; }
        public Proizvod Proizvod { get; set; }
    }

}
