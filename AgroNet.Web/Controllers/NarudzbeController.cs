using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AgroNet.Model;
using AgroNet.Web.Models;
using System.Threading.Tasks;
using AgroNet.DAL;

namespace AgroNet.Web.Controllers
{
    public class NarudzbeController : Controller
    {
        private readonly AgroNetDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public NarudzbeController(AgroNetDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Narudzbe
        public async Task<IActionResult> Index(bool showFinished = false)
        {
            var userEmail = User.Identity.Name;

            var vlasnik = _context.Vlasnici.FirstOrDefault(v => v.Email == userEmail);

            var vlasnikOpg = _context.VlasniciOPG.FirstOrDefault(vo => vo.VlasnikId == vlasnik.Id);

            var currentUser = _context.OPGs.FirstOrDefault(o => o.Id == vlasnikOpg.OPGId);

            ViewBag.currentUser=currentUser;

            var narudzbeQuery = _context.Narudzbe.AsQueryable();

            if (showFinished)
            {
                narudzbeQuery = narudzbeQuery.Where(n => n.StatusNarudzbeId == 4 || n.StatusNarudzbeId == 5 || n.StatusNarudzbeId == 6);
                ViewBag.ShowFinished = true;
            }
            else
            {
                narudzbeQuery = narudzbeQuery.Where(n => n.StatusNarudzbeId < 4);
                ViewBag.ShowFinished = false;
            }

            narudzbeQuery = narudzbeQuery.Where(n => n.KupacOPGId == currentUser.Id || n.ProdavacOPGId == currentUser.Id);

            var narudzbe = await narudzbeQuery
        .Include(n => n.KupacOPG)
        .Include(n => n.ProdavacOPG)
        .Include(n => n.StatusNarudzbe)
        .Include(n => n.StavkeNarudzbeUsluga)
        .Include(n => n.StavkeNarudzbeProizvod)
        .ToListAsync();

            var viewModel = narudzbe.Select(n => new NarudzbaViewModel
            {
                Id = n.Id,
                KupacOPGNaziv = n.KupacOPG?.Naziv, // Safe navigation with ?.
                ProdavacOPGNaziv = n.ProdavacOPG?.Naziv,
                DatumNarudzbe = n.DatumNarudzbe,
                DatumIsporuke = n.DatumIsporuke,
                StatusNarudzbeNaziv = n.StatusNarudzbe?.Naziv,
                StavkeUsluga = n.StavkeNarudzbeUsluga?.Where(s => s != null).Select(s => new StavkaViewModel
                {
                    Naziv = s.Usluga?.Naziv,
                    Kolicina = s.Kolicina,
                    JedinicnaCijena = s.JedinicnaCijena
                }).ToList() ?? new List<StavkaViewModel>(), // Ensure the list is not null
                StavkeProizvodi = n.StavkeNarudzbeProizvod?.Where(s => s != null).Select(s => new StavkaViewModel
                {
                    Naziv = s.Proizvod?.Naziv,
                    Kolicina = (int)s.Kolicina,
                    JedinicnaCijena = s.JedinicnaCijena
                }).ToList() ?? new List<StavkaViewModel>(), // Ensure the list is not null
                IsKupac = (n.KupacOPG?.Id == currentUser.Id) && (n.ProdavacOPG?.Id != currentUser.Id),
                IsProdavac = (n.KupacOPG?.Id != currentUser.Id) && (n.ProdavacOPG?.Id == currentUser.Id),
                IsBoth =(n.KupacOPG?.Id==currentUser.Id) && (n.ProdavacOPG?.Id == currentUser.Id)
            });

            return View(viewModel);
        }

        // GET: Narudzbe/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var narudzba = await _context.Narudzbe
                .Include(n => n.KupacOPG)
                .Include(n => n.ProdavacOPG)
                .Include(n => n.StatusNarudzbe)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (narudzba == null)
            {
                return NotFound();
            }

            var stavkeUsluga = await _context.StavkeNarudzbeUsluga
                .Include(s => s.Usluga)
                .Where(s => s.NarudzbaId == id)
                .ToListAsync();

            var stavkeProizvodi = await _context.StavkeNarudzbeProizvoda
                .Include(s => s.Proizvod)
                .Where(s => s.NarudzbaId == id)
                .ToListAsync();

            

            var userEmail = User.Identity.Name;

            var vlasnik = _context.Vlasnici.FirstOrDefault(v => v.Email == userEmail);

            var vlasnikOpg = _context.VlasniciOPG.FirstOrDefault(vo => vo.VlasnikId == vlasnik.Id);

            var opgTrenutniKorisnik = _context.OPGs.FirstOrDefault(o => o.Id == vlasnikOpg.OPGId);



            var isKupac = (narudzba.KupacOPG?.Id == opgTrenutniKorisnik.Id) && (narudzba.ProdavacOPG?.Id != opgTrenutniKorisnik.Id);

            var isProdavac = (narudzba.KupacOPG?.Id != opgTrenutniKorisnik.Id) && (narudzba.ProdavacOPG?.Id == opgTrenutniKorisnik.Id);

            var IsBoth = (narudzba.KupacOPG?.Id == opgTrenutniKorisnik.Id) && (narudzba.ProdavacOPG?.Id == opgTrenutniKorisnik.Id);

            var model = new NarudzbaDetailsViewModel
            {
                Narudzba = narudzba,
                StavkeUsluga = stavkeUsluga,
                StavkeProizvodi = stavkeProizvodi,
                IsKupac = isKupac,
                IsProdavac = isProdavac
            };

            return View(model);
        }

        // GET: Narudzbe/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var narudzba = await _context.Narudzbe.FindAsync(id);

            if (narudzba == null)
            {
                return NotFound();
            }

            var model = new NarudzbaEditViewModel
            {
                Id = narudzba.Id,
                KupacOPGId = narudzba.KupacOPGId,
                ProdavacOPGId = narudzba.ProdavacOPGId,
                DatumNarudzbe = narudzba.DatumNarudzbe,
                DatumIsporuke = narudzba.DatumIsporuke,
                StatusNarudzbeId = narudzba.StatusNarudzbeId
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(NarudzbaEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var narudzba = await _context.Narudzbe.FindAsync(model.Id);
                if (narudzba == null)
                {
                    return NotFound();
                }

                narudzba.DatumNarudzbe = model.DatumNarudzbe;
                narudzba.DatumIsporuke = model.DatumIsporuke;
                narudzba.StatusNarudzbeId = model.StatusNarudzbeId;

                _context.Update(narudzba);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        // POST: Narudzbe/Cancel/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cancel(int id)
        {
            var narudzba = await _context.Narudzbe.FindAsync(id);
            if (narudzba == null)
            {
                return NotFound();
            }

            narudzba.StatusNarudzbeId = 6; // Assuming 2 is the ID for "Cancelled" status

            _context.Update(narudzba);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // POST: Narudzbe/Accept/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Accept(int id)
        {
            var narudzba = await _context.Narudzbe.FindAsync(id);
            if (narudzba == null)
            {
                return NotFound();
            }

            narudzba.StatusNarudzbeId = 2; // Assuming 3 is the ID for "Accepted" status

            _context.Update(narudzba);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // POST: Narudzbe/Decline/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Decline(int id)
        {
            var narudzba = await _context.Narudzbe.FindAsync(id);
            if (narudzba == null)
            {
                return NotFound();
            }

            narudzba.StatusNarudzbeId = 5; // Assuming 4 is the ID for "Declined" status

            _context.Update(narudzba);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Finish(int id)
        {
            var narudzba = await _context.Narudzbe.FindAsync(id);
            if (narudzba == null)
            {
                return NotFound();
            }

            narudzba.StatusNarudzbeId = 4; // Assuming 5 is the ID for "Finished" status

            _context.Update(narudzba);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Details), new { id = id });
        }
    }
}
