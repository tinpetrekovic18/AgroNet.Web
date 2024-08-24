using AgroNet.DAL;
using AgroNet.Model;
using AgroNet.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AgroNet.Web.Controllers
{
    public class ProizvodiController : Controller
    {
        private readonly AgroNetDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public ProizvodiController(AgroNetDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Proizvodi(ProizvodFilterModel filter)
        {
            ViewBag.VrsteProizvoda = new SelectList(_context.VrsteProizvoda, "Id", "Naziv");
            ViewBag.Zupanije = new SelectList(_context.Zupanije, "Id", "Naziv");

            filter ??= new ProizvodFilterModel();

            var proizvodiQuery = _context.OPGProizvodi
                .Include(p => p.Proizvod)
                .Include(p => p.Proizvod.VrstaProizvoda)
                .Include(p => p.OPG)
                .Include(p => p.OPG.Mjesto)
                .Include(p => p.OPG.Mjesto.Zupanija)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(filter.NazivProizvoda))
                proizvodiQuery = proizvodiQuery.Where(p => p.Proizvod.Naziv.ToLower().Contains(filter.NazivProizvoda.ToLower()));

            if (filter.VrstaProizvodaId != null)
                proizvodiQuery = proizvodiQuery.Where(p => p.Proizvod.VrstaProizvoda.Id == filter.VrstaProizvodaId);

            if (!string.IsNullOrWhiteSpace(filter.NazivOPG))
                proizvodiQuery = proizvodiQuery.Where(p => p.OPG.Naziv.ToLower().Contains(filter.NazivOPG.ToLower()));

            if (!string.IsNullOrWhiteSpace(filter.NazivMjesta))
                proizvodiQuery = proizvodiQuery.Where(p => p.OPG.Mjesto.Naziv.ToLower().Contains(filter.NazivMjesta.ToLower()));

            if (filter.ZupanijaId!=null)
                proizvodiQuery = proizvodiQuery.Where(p => p.OPG.Mjesto.Zupanija.Id == filter.ZupanijaId);

            var model = proizvodiQuery.ToList();
            return View(model);
        }

        public IActionResult Details(int id)
        {
            var proizvod = _context.OPGProizvodi
                .Include(p => p.Proizvod)
                .Include(p => p.Proizvod.VrstaProizvoda)
                .Include(p => p.OPG)
                .Include(p => p.OPG.Mjesto)
                .Include(p => p.OPG.Mjesto.Zupanija)
                .FirstOrDefault(p => p.Id == id);

            if (proizvod == null)
            {
                return NotFound();
            }

            // Fetch the Vlasnik related to the OPG
            var vlasnik = _context.VlasniciOPG
                .Where(vo => vo.OPGId == proizvod.OPG.Id)
                .Include(vo => vo.Vlasnik)
                .Select(vo => vo.Vlasnik)
                .FirstOrDefault();

            var model = new ProizvodDetailsViewModel
            {
                Proizvod = proizvod,
                Vlasnik = vlasnik
            };

            return View(model);
        }
        public IActionResult CreateOrder(int proizvodId, int prodavacOpgId)
        {
            var proizvod = _context.Proizvodi.Find(proizvodId);
            var opg = _context.OPGs.Find(prodavacOpgId);
            var currentUser = _userManager.GetUserAsync(User).Result;

            if (proizvod == null || opg == null || currentUser == null)
            {
                return NotFound();
            }

            var userEmail = User.Identity.Name;

            var vlasnik = _context.Vlasnici.FirstOrDefault(v => v.Email == userEmail);

            var vlasnikOpg = _context.VlasniciOPG.FirstOrDefault(vo => vo.VlasnikId == vlasnik.Id);

            var opgKupac = _context.OPGs.FirstOrDefault(o => o.Id == vlasnikOpg.OPGId);

            if (opgKupac == null)
            {
                return Unauthorized(); // or handle appropriately if the user doesn't have an associated OPG
            }

            var model = new NarudzbaProizvodCreateViewModel
            {
                ProizvodId = proizvod.Id,
                ProizvodNaziv = proizvod.Naziv,
                ProdavacOpgId = opg.Id,
                ProdavacOpgNaziv = opg.Naziv,
                KupacOpgId = opgKupac.Id
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOrder(NarudzbaProizvodCreateViewModel model)
        {
            var userEmail = User.Identity.Name;

            var vlasnik = _context.Vlasnici.FirstOrDefault(v => v.Email == userEmail);

            var vlasnikOpg = _context.VlasniciOPG.FirstOrDefault(vo => vo.VlasnikId == vlasnik.Id);

            var opgKupac = _context.OPGs.FirstOrDefault(o => o.Id == vlasnikOpg.OPGId);

            if (ModelState.IsValid)
            {
                var narudzba = new Narudzba
                {
                    KupacOPGId = opgKupac.Id,
                    ProdavacOPGId = model.ProdavacOpgId,
                    StatusNarudzbeId = 1, // Assuming 1 is the ID for "Pending" status, adjust as needed
                    DatumNarudzbe = DateTime.Now
                };

                _context.Narudzbe.Add(narudzba);
                await _context.SaveChangesAsync();

                var stavkaProizvod = new StavkaNarudzbeProizvod
                {
                    NarudzbaId = narudzba.Id,
                    ProizvodId = model.ProizvodId,
                    Kolicina = model.Kolicina,
                    JedinicnaCijena = model.JedinicnaCijena
                };

                _context.StavkeNarudzbeProizvoda.Add(stavkaProizvod);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index", "Narudzbe");
            }

            return View(model);
        }

    }
}
