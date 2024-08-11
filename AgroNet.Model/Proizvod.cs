﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroNet.Model
{
    public class Proizvod
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("VrstaProizvoda")]
        public int VrstaProizvodaId { get; set; }

        [Required]  
        public string Naziv { get; set; }

        public string Opis { get; set; }

        public VrstaProizvoda VrstaProizvoda { get; set; }
    }

}
