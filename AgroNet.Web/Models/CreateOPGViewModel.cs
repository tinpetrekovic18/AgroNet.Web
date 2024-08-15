using Microsoft.AspNetCore.Mvc.Rendering;

namespace AgroNet.Web.Models
{
    public class CreateOPGViewModel
    {
        public string Naziv { get; set; }
        public string Adresa { get; set; }
        public string IBAN { get; set; }
        public int MjestoId { get; set; }

        public string VlasnikName { get; set; }  // Displayed but disabled
        public int DjelatnostId { get; set; }    // Selected by user

        public List<SelectListItem> Mjesta { get; set; }
        public List<SelectListItem> Djelatnosti { get; set; }
    }

}
