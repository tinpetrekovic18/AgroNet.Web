using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroNet.Model
{
    public class Imanje
    {
        [Key]
        public int Id { get; set; }

        public string Katastar { get; set; }

        public int? Povrsina { get; set; }
    }
}
