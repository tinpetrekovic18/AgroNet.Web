using Microsoft.AspNetCore.Mvc;

namespace AgroNet.Web.Models
{
    public class NarudzbaCreateViewModel
    {
        public int UslugaId { get; set; } //
        public string UslugaNaziv { get; set; }
        public int ProdavacOPGId { get; set; } //
        public string ProdavacOPGNaziv { get; set; }
        public int KupacOPGId { get; set; }  //
        public int StatusNarudzbeId { get; set; } //
        public int Kolicina { get; set; } //
        public decimal? JedinicnaCijena { get; set; } //

        
    }
}
