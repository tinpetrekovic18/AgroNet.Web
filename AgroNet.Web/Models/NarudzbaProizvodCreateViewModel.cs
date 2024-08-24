using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace AgroNet.Web.Models
{
    public class NarudzbaProizvodCreateViewModel
    {
        [Required]
        public int ProizvodId { get; set; }

        public string ProizvodNaziv { get; set; }

        [Required]
        public int ProdavacOpgId { get; set; }

        public string ProdavacOpgNaziv { get; set; }

        [Required]
        public int KupacOpgId { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Kolicina mora biti veća od 0.")]
        public int Kolicina { get; set; }

        [Required]
        
        public decimal JedinicnaCijena { get; set; }
    }
}
