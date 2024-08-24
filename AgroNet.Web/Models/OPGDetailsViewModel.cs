using AgroNet.Model;
using Microsoft.AspNetCore.Mvc;

namespace AgroNet.Web.Models
{
    public class OPGDetailsViewModel
    {
        public OPG OPG { get; set; }
        public List<Vlasnik> Vlasnici { get; set; }
        public Djelatnost Djelatnost { get; set; }  
        public List<OPGUsluga> Usluge { get; set; }  // Add this
        public List<OPGProizvod> Proizvodi { get; set; }  // Add this
        public List<OPGStrojeviAlati> StrojeviAlati { get; set; }  // Add this
    }
}
