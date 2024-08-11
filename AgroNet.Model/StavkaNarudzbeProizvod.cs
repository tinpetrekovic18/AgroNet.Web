using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroNet.Model
{
    public class StavkaNarudzbeProizvod
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Narudzba")]
        public int NarudzbaId { get; set; }

        [Required]
        [ForeignKey("Proizvod")]
        public int ProizvodId { get; set; }

        public int? Kolicina { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal? JedinicnaCijena { get; set; }

        public Narudzba Narudzba { get; set; }
        public Proizvod Proizvod { get; set; }
    }

}
