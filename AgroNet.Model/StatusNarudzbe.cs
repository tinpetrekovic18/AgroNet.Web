using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroNet.Model
{
    public class StatusNarudzbe
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Naziv { get; set; }

        public string Opis { get; set; }
    }

}
