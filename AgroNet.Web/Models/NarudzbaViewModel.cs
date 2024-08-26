using AgroNet.Model;
using Microsoft.AspNetCore.Mvc;

namespace AgroNet.Web.Models
{
    public class NarudzbaViewModel
    {
        public int Id { get; set; }
        public string KupacOPGNaziv { get; set; }
        public string ProdavacOPGNaziv { get; set; }
        public DateTime? DatumNarudzbe { get; set; }
        public DateTime? DatumIsporuke { get; set; }
        public string StatusNarudzbeNaziv { get; set; }

      /*  public IEnumerable<StavkaViewModel> StavkeUsluga { get; set; }
        public IEnumerable<StavkaViewModel> StavkeProizvodi { get; set; }*/

        public List<StavkaNarudzbeUsluga> StavkeUsluga { get; set; }
        public List<StavkaNarudzbeProizvod> StavkeProizvodi { get; set; }
        public bool IsKupac { get; set; }
        public bool IsProdavac { get; set; }

        public bool IsBoth { get; set; }
    }

    public class StavkaViewModel
    {
        public string Naziv { get; set; }
        public int Kolicina { get; set; }
        public decimal? JedinicnaCijena { get; set; }
    }
}
