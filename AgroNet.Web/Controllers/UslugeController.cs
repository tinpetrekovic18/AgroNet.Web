using AgroNet.DAL;
using AgroNet.Model;
using AgroNet.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


namespace AgroNet.Web.Controllers
{
    public class UslugeController : Controller
    {

        private readonly AgroNetDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public UslugeController(AgroNetDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public IActionResult Usluge(UslugeFilterModel filter)
        {
            // Create a list of SelectListItems for VrstaUsluge with a default "All" option
            var vrsteUslugaList = _context.VrsteUsluga
                .Select(vrsta => new SelectListItem
                {
                    Value = vrsta.Id.ToString(),
                    Text = vrsta.Naziv
                }).ToList();

            vrsteUslugaList.Insert(0, new SelectListItem { Text = "Sve vrste usluga", Value = "" });

            // Create a list of SelectListItems for Zupanije with a default "All" option
            var zupanijeList = _context.Zupanije
                .Select(zupanija => new SelectListItem
                {
                    Value = zupanija.Id.ToString(),
                    Text = zupanija.Naziv
                }).ToList();

            zupanijeList.Insert(0, new SelectListItem { Text = "Sve županije", Value = "" });

            ViewBag.VrsteUsluga = new SelectList(vrsteUslugaList, "Value", "Text");
            ViewBag.Zupanije = new SelectList(zupanijeList, "Value", "Text");

            filter ??= new UslugeFilterModel();

            var uslugeOPGQuery = _context.OPGUsluge
                .Include(u => u.Usluga)
                .Include(u => u.Usluga.VrstaUsluge)
                .Include(u => u.OPG)
                .Include(u => u.OPG.Mjesto)
                .Include(u => u.OPG.Mjesto.Zupanija)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(filter.NazivUsluge))
                uslugeOPGQuery = uslugeOPGQuery.Where(p => p.Usluga.Naziv.ToLower().Contains(filter.NazivUsluge.ToLower()));

            if (filter.VrstaUslugeId.HasValue)
                uslugeOPGQuery = uslugeOPGQuery.Where(p => p.Usluga.VrstaUsluge.Id == filter.VrstaUslugeId);

            if (!string.IsNullOrWhiteSpace(filter.NazivOPG))
                uslugeOPGQuery = uslugeOPGQuery.Where(p => p.OPG.Naziv.ToLower().Contains(filter.NazivOPG.ToLower()));

            if (!string.IsNullOrWhiteSpace(filter.NazivMjesta))
                uslugeOPGQuery = uslugeOPGQuery.Where(p => p.OPG.Mjesto.Naziv.ToLower().Contains(filter.NazivMjesta.ToLower()));

            if (filter.ZupanijaId.HasValue)
                uslugeOPGQuery = uslugeOPGQuery.Where(p => p.OPG.Mjesto.Zupanija.Id == filter.ZupanijaId);

            var model = uslugeOPGQuery.ToList();
            return View("Usluge", model);
        }


        public IActionResult Details(int id)
        {
            var usluga = _context.OPGUsluge
                .Include(u => u.Usluga)
                .Include(u => u.Usluga.VrstaUsluge)
                .Include(u => u.OPG)
                .Include(u => u.OPG.Mjesto)
                .Include(u => u.OPG.Mjesto.Zupanija)
                .FirstOrDefault(u => u.Id == id); // Assuming Id is the primary key for OPGUsluge

            if (usluga == null)
            {
                return NotFound();
            }

            // Fetch the Vlasnik related to the OPG
            var vlasnik = _context.VlasniciOPG
                .Where(vo => vo.OPGId == usluga.OPG.Id)
                .Include(vo => vo.Vlasnik)
                .Select(vo => vo.Vlasnik)
                .FirstOrDefault();

            // Create a view model to pass both usluga and vlasnik data to the view
            var model = new UslugaDetailsViewModel
            {
                Usluga = usluga,
                Vlasnik = vlasnik
            };

            return View(model);
        }


        [HttpGet]
        public IActionResult CreateOrder(int uslugaId, int prodavacOpgId)
        {
            // Fetch Usluga and OPG details to pre-fill form fields
            var usluga = _context.Usluge.FirstOrDefault(u => u.Id == uslugaId);
            var prodavacOpg = _context.OPGs.FirstOrDefault(o => o.Id == prodavacOpgId);


            if (usluga == null || prodavacOpg == null)
            {
                return NotFound();
            }

            // Create a view model if needed
            var model = new NarudzbaCreateViewModel
            {
                UslugaId = usluga.Id,
                ProdavacOPGId = prodavacOpg.Id,
                UslugaNaziv = usluga.Naziv,
                ProdavacOPGNaziv = prodavacOpg.Naziv,
                // Initialize other fields as needed
            };

            return View(model);
        }

        // Handle form submission
        [HttpPost]
        public IActionResult CreateOrder(NarudzbaCreateViewModel model)
        {
            var userEmail = User.Identity.Name;
            
            var vlasnik = _context.Vlasnici.FirstOrDefault(v => v.Email == userEmail);
 
            var vlasnikOpg = _context.VlasniciOPG.FirstOrDefault(vo => vo.VlasnikId == vlasnik.Id);

            var opgKupac = _context.OPGs.FirstOrDefault(o => o.Id == vlasnikOpg.OPGId);
            
            if (ModelState.IsValid)
            {
                // Create new Narudzba and StavkaNarudzbeUsluga
                var narudzba = new Narudzba
                {
                    KupacOPGId = opgKupac.Id, // Assume KupacOPGId is provided
                    ProdavacOPGId = model.ProdavacOPGId,
                    DatumNarudzbe = DateTime.Now,
                    StatusNarudzbeId = 1 
                };

                _context.Narudzbe.Add(narudzba);
                _context.SaveChanges();

                var stavkaNarudzbeUsluga = new StavkaNarudzbeUsluga
                {
                    NarudzbaId = narudzba.Id,
                    UslugaId = model.UslugaId,
                    Kolicina = model.Kolicina,
                    JedinicnaCijena = model.JedinicnaCijena
                };

                _context.StavkeNarudzbeUsluga.Add(stavkaNarudzbeUsluga);
                _context.SaveChanges();

                return RedirectToAction("Index", "Narudzbe");
            }

            // Reload data in case of validation failure
            return View(model);
        }



    }
}
