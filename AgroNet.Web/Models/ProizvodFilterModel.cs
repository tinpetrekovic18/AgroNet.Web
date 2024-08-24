using Microsoft.AspNetCore.Mvc;

namespace AgroNet.Web.Models
{
    public class ProizvodFilterModel
    {
        public string NazivProizvoda { get; set; }
        public int? VrstaProizvodaId { get; set; }
        public string NazivOPG { get; set; }
        public string NazivMjesta { get; set; }
        public int? ZupanijaId { get; set; }
    }
}
