using AgroNet.Model;
using Microsoft.AspNetCore.Mvc;

namespace AgroNet.Web.Models
{
    public class ProizvodDetailsViewModel
    {
        public OPGProizvod Proizvod { get; set; }
        public Vlasnik Vlasnik { get; set; }
    }
}
