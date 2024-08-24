using AgroNet.Model;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AgroNet.Web.Models
{
    public class NarudzbaEditViewModel
    {
        public int Id { get; set; }

        [Required]
        public int KupacOPGId { get; set; }

        [Required]
        public int ProdavacOPGId { get; set; }

        [Required]
        [Display(Name = "Datum Narudžbe")]
        public DateTime? DatumNarudzbe { get; set; }

        [Display(Name = "Datum Isporuke")]
        public DateTime? DatumIsporuke { get; set; }

        [Required]
        public int StatusNarudzbeId { get; set; }
    }
}
