using Microsoft.AspNetCore.Mvc;

namespace AgroNet.Web.Models
{
    public class OPGFilterModel
    {
        public string NazivOPG { get; set; }
        public string NazivMjesta { get; set; }
        public int? ZupanijaId { get; set; }
    }
}
