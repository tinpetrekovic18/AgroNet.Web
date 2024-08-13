using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroNet.Model
{
    public class Mjesto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Naziv { get; set; }

        [Required]
        public int? PostanskiBroj { get; set; }

        [Required]
        [ForeignKey("Zupanija")]
        public int ZupanijaId { get; set; }

        public Zupanija Zupanija { get; set; }
    }

}
