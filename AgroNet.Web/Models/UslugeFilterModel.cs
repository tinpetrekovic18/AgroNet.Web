using AgroNet.Model;
using Microsoft.AspNetCore.Mvc;

namespace AgroNet.Web.Models
{
    public class UslugeFilterModel
    {
        public string NazivUsluge { get; set; }
        public int? VrstaUslugeId { get; set; }  // Nullable int
        public string NazivOPG { get; set; }
        public string NazivMjesta { get; set; }
        public int? ZupanijaId { get; set; }  // Nullable int
    }



}
