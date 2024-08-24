using AgroNet.Model;
using Microsoft.AspNetCore.Mvc;

namespace AgroNet.Web.Models
{
    public class NarudzbaDetailsViewModel
    {
        public Narudzba Narudzba { get; set; }
        public List<StavkaNarudzbeUsluga> StavkeUsluga { get; set; }
        public List<StavkaNarudzbeProizvod> StavkeProizvodi { get; set; }
        public bool IsKupac { get; set; }
        public bool IsProdavac { get; set; }
        public bool IsBoth { get; set; }
    }
}
