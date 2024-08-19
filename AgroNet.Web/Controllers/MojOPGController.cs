using Microsoft.AspNetCore.Mvc;
using AgroNet.DAL;
using AgroNet.Model;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
public class MojOPGController : Controller
{
    private readonly AgroNetDbContext _context;
    private readonly UserManager<AppUser> _userManager;

    public MojOPGController(AgroNetDbContext context, UserManager<AppUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    // GET: MojOPG/Create or Edit
    public async Task<IActionResult> CreateOrEdit()
    {
        var userEmail = User.Identity.Name;
        if (userEmail == null)
        {
            return Unauthorized("User is not logged in.");
        }

        var vlasnik = _context.Vlasnici.FirstOrDefault(v => v.Email == userEmail);
        if (vlasnik == null)
        {
            return NotFound("Vlasnik not found.");
        }

        var vlasnikOpg = _context.VlasniciOPG.FirstOrDefault(vo => vo.VlasnikId == vlasnik.Id);
        if (vlasnikOpg != null)
        {
            return RedirectToAction("Edit", new { id = vlasnikOpg.OPGId });
        }

        ViewBag.Mjesta = new SelectList(_context.Mjesta, "Id", "Naziv");
        ViewBag.Djelatnosti = new SelectList(_context.Djelatnosti, "Id", "Naziv");
        ViewBag.IsEditMode = false; // Indicate that this is a create operation
        return View("Create");
    }

    // POST: MojOPG/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(OPG opg, int? DjelatnostId)
    {
        var userEmail = User.Identity.Name;
        if (userEmail == null)
        {
            return Unauthorized("User is not logged in.");
        }

        var vlasnik = _context.Vlasnici.FirstOrDefault(v => v.Email == userEmail);
        if (vlasnik == null)
        {
            return NotFound("Vlasnik not found.");
        }

        if (_context.VlasniciOPG.Any(vo => vo.VlasnikId == vlasnik.Id))
        {
            return RedirectToAction("CreateOrEdit");
        }

        ModelState.Remove(nameof(opg.Mjesto));
        if (ModelState.IsValid)
        {
            opg.Mjesto = _context.Mjesta.Find(opg.MjestoId);
            _context.OPGs.Add(opg);
            _context.SaveChanges();

            var vlasnikOpg = new VlasnikOPG
            {
                VlasnikId = vlasnik.Id,
                OPGId = opg.Id
            };

            _context.VlasniciOPG.Add(vlasnikOpg);

            if (DjelatnostId.HasValue)
            {
                var djelatnostiOpg = new DjelatnostiOPG
                {
                    OPGId = opg.Id,
                    DjelatnostId = DjelatnostId.Value
                };

                _context.DjelatnostiOPG.Add(djelatnostiOpg);
            }

            _context.SaveChanges();
            return RedirectToAction("CreateOrEdit");
        }

        ViewBag.Mjesta = new SelectList(_context.Mjesta, "Id", "Naziv", opg.MjestoId);
        ViewBag.Djelatnosti = new SelectList(_context.Djelatnosti, "Id", "Naziv", DjelatnostId);
        ViewBag.IsEditMode = false;
        return View("Create", opg);
    }

    public IActionResult CreateStrojAlat(int opgId)
    {
        ViewBag.OPGId = opgId;
        ViewBag.VrstaStrojaAlataList = new SelectList(_context.VrsteStrojevaAlata, "Id", "Naziv");
        return View(new StrojAlat());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult CreateStrojAlat(StrojAlat strojAlat, int opgId)
    {
        ModelState.Remove(nameof(strojAlat.VrstaStrojaAlata));
        if (ModelState.IsValid)
        {
            _context.StrojeviAlati.Add(strojAlat);
            _context.SaveChanges();

            var opgStrojAlat = new OPGStrojeviAlati
            {
                OPGId = opgId,
                StrojAlatId = strojAlat.Id
            };

            _context.OPGStrojeviAlati.Add(opgStrojAlat);
            _context.SaveChanges();

            return RedirectToAction("Edit", new { id = opgId, activeTab = "strojeviAlati" });
        }

        ViewBag.OPGId = opgId;
        ViewBag.VrstaStrojaAlataList = new SelectList(_context.VrsteStrojevaAlata, "Id", "Naziv", strojAlat.VrstaStrojaAlataId);
        return View(strojAlat);
    }

    public IActionResult CreateUsluga(int opgId)
    {
        ViewBag.OPGId = opgId;
        ViewBag.VrstaUslugeList = new SelectList(_context.VrsteUsluga, "Id", "Naziv");
        return View(new Usluga());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult CreateUsluga(Usluga usluga, int opgId)
    {
        ModelState.Remove(nameof(usluga.VrstaUsluge));
        if (ModelState.IsValid)
        {
            _context.Usluge.Add(usluga);
            _context.SaveChanges();

            var opgUsluga = new OPGUsluga
            {
                OPGId = opgId,
                UslugaId = usluga.Id
            };

            _context.OPGUsluge.Add(opgUsluga);
            _context.SaveChanges();

            return RedirectToAction("Edit", new { id = opgId, activeTab = "usluge" });
        }

        ViewBag.OPGId = opgId;
        ViewBag.VrstaUslugeList = new SelectList(_context.VrsteUsluga, "Id", "Naziv", usluga.VrstaUslugeId);
        return View(usluga);
    }

    public IActionResult Edit(int id)
    {
        var opg = _context.OPGs
            .Include(o => o.Mjesto)
            .FirstOrDefault(o => o.Id == id);

        if (opg == null)
        {
            return NotFound();
        }

        var linkedDjelatnost = _context.DjelatnostiOPG
            .FirstOrDefault(d => d.OPGId == id);
        int? selectedDjelatnostId = linkedDjelatnost?.DjelatnostId;

        ViewBag.Mjesta = new SelectList(_context.Mjesta, "Id", "Naziv", opg.MjestoId);
        ViewBag.Djelatnosti = new SelectList(_context.Djelatnosti, "Id", "Naziv", selectedDjelatnostId);

        ViewBag.Proizvodi = _context.OPGProizvodi
    .Where(op => op.OPGId == id)
    .Select(op => new
    {
        op.Proizvod.Id, // Include Id
        op.Proizvod.Naziv,
        op.Proizvod.Opis,
        VrstaProizvodaNaziv = op.Proizvod.VrstaProizvoda.Naziv
    })
    .ToList();



        ViewBag.StrojeviAlati = _context.OPGStrojeviAlati
    .Where(os => os.OPGId == id)
    .Select(os => new
    {
        os.StrojAlat.Id, // Include Id
        os.StrojAlat.Naziv,
        os.StrojAlat.Opis,
        VrstaStrojaAlataNaziv = os.StrojAlat.VrstaStrojaAlata.Naziv
    })
    .ToList();


        ViewBag.Usluge = _context.OPGUsluge
    .Where(ou => ou.OPGId == id)
    .Select(ou => new
    {
        ou.Usluga.Id, // Include Id
        ou.Usluga.Naziv,
        ou.Usluga.Opis,
        VrstaUslugeNaziv = ou.Usluga.VrstaUsluge.Naziv
    })
    .ToList();


        ViewBag.IsEditMode = true;
        return View("Edit", opg);
    }





    // GET: MojOPG/CreateProizvod
    public IActionResult CreateProizvod(int opgId)
    {
        ViewBag.OPGId = opgId;
        ViewBag.VrstaProizvodaList = new SelectList(_context.VrsteProizvoda, "Id", "Naziv");
        return View(new Proizvod());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult CreateProizvod(Proizvod proizvod, int opgId)
    {
        ModelState.Remove(nameof(proizvod.VrstaProizvoda));
        if (ModelState.IsValid)
        {
            _context.Proizvodi.Add(proizvod);
            _context.SaveChanges();

            var opgProizvod = new OPGProizvod
            {
                OPGId = opgId,
                ProizvodId = proizvod.Id
            };

            _context.OPGProizvodi.Add(opgProizvod);
            _context.SaveChanges();

            return RedirectToAction("Edit", new { id = opgId, activeTab = "proizvodi" });
        }

        // If we reach this point, something went wrong
        ViewBag.OPGId = opgId;
        ViewBag.VrstaProizvodaList = new SelectList(_context.VrsteProizvoda, "Id", "Naziv", proizvod.VrstaProizvodaId);
        return View(proizvod);
    }





    // POST: MojOPG/Edit
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(OPG opg, int? DjelatnostId)
    {
        var userEmail = User.Identity.Name;
        if (userEmail == null)
        {
            return Unauthorized("User is not logged in.");
        }

        var vlasnik = _context.Vlasnici.FirstOrDefault(v => v.Email == userEmail);
        if (vlasnik == null)
        {
            return NotFound("Vlasnik not found.");
        }

        if (!_context.VlasniciOPG.Any(vo => vo.OPGId == opg.Id && vo.VlasnikId == vlasnik.Id))
        {
            return Unauthorized();
        }

        ModelState.Remove(nameof(opg.Mjesto));
        if (ModelState.IsValid)
        {
            _context.Update(opg);

            var existingDjelatnosti = _context.DjelatnostiOPG.Where(d => d.OPGId == opg.Id).ToList();
            _context.DjelatnostiOPG.RemoveRange(existingDjelatnosti);

            if (DjelatnostId.HasValue)
            {
                var djelatnostiOpg = new DjelatnostiOPG
                {
                    OPGId = opg.Id,
                    DjelatnostId = DjelatnostId.Value
                };

                _context.DjelatnostiOPG.Add(djelatnostiOpg);
            }

            _context.SaveChanges();
            return RedirectToAction("CreateOrEdit");
        }

        ViewBag.Mjesta = new SelectList(_context.Mjesta, "Id", "Naziv", opg.MjestoId);
        ViewBag.Djelatnosti = new SelectList(_context.Djelatnosti, "Id", "Naziv", DjelatnostId);
        ViewBag.IsEditMode = true;
        return View("Edit", opg);
    }

    // DELETE: MojOPG/DeleteProizvod/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteProizvod(int id, int opgId)
    {
        var opgProizvod = _context.OPGProizvodi.FirstOrDefault(op => op.ProizvodId == id && op.OPGId == opgId);
        if (opgProizvod != null)
        {
            _context.OPGProizvodi.Remove(opgProizvod);
            _context.SaveChanges();
        }

        return RedirectToAction("Edit", new { id = opgId, activeTab = "proizvodi" });
    }

        // DELETE: MojOPG/DeleteStrojAlat/5
        [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteStrojAlat(int id, int opgId)
    {
        var opgStrojAlat = _context.OPGStrojeviAlati.FirstOrDefault(os => os.StrojAlatId == id && os.OPGId == opgId);
        if (opgStrojAlat != null)
        {
            _context.OPGStrojeviAlati.Remove(opgStrojAlat);
            _context.SaveChanges();
        }

            return RedirectToAction("Edit", new { id = opgId, activeTab = "strojeviAlati" });
        
    }

    // DELETE: MojOPG/DeleteUsluga/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteUsluga(int id, int opgId)
    {
        var opgUsluga = _context.OPGUsluge.FirstOrDefault(ou => ou.UslugaId == id && ou.OPGId == opgId);
        if (opgUsluga != null)
        {
            _context.OPGUsluge.Remove(opgUsluga);
            _context.SaveChanges();
        }

            return RedirectToAction("Edit", new { id = opgId, activeTab = "usluge" });
    }

    // GET: MojOPG/EditProizvod/5
    public IActionResult EditProizvod(int id, int opgId)
    {
        var proizvod = _context.Proizvodi.FirstOrDefault(p => p.Id == id);
        if (proizvod == null)
        {
            return NotFound();
        }

        ViewBag.OPGId = opgId;
        ViewBag.VrstaProizvodaList = new SelectList(_context.VrsteProizvoda, "Id", "Naziv", proizvod.VrstaProizvodaId);
        return View(proizvod);
    }

    // POST: MojOPG/EditProizvod/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult EditProizvod(Proizvod proizvod, int opgId)
    {
        ModelState.Remove(nameof(proizvod.VrstaProizvoda));
        if (ModelState.IsValid)
        {
            _context.Update(proizvod);
            _context.SaveChanges();

            return RedirectToAction("Edit", new { id = opgId, activeTab = "proizvodi" });
        }

        ViewBag.OPGId = opgId;
        ViewBag.VrstaProizvodaList = new SelectList(_context.VrsteProizvoda, "Id", "Naziv", proizvod.VrstaProizvodaId);
        return View(proizvod);
    }

    // GET: MojOPG/EditUsluga/5
    public IActionResult EditUsluga(int id, int opgId)
    {
        var usluga = _context.Usluge.FirstOrDefault(u => u.Id == id);
        if (usluga == null)
        {
            return NotFound();
        }

        ViewBag.OPGId = opgId;
        ViewBag.VrstaUslugeList = new SelectList(_context.VrsteUsluga, "Id", "Naziv", usluga.VrstaUslugeId);
        return View(usluga);
    }

    // POST: MojOPG/EditUsluga/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult EditUsluga(Usluga usluga, int opgId)
    {
        ModelState.Remove(nameof(usluga.VrstaUsluge));
        if (ModelState.IsValid)
        {
            _context.Update(usluga);
            _context.SaveChanges();

            return RedirectToAction("Edit", new { id = opgId, activeTab = "usluge" });
        }

        ViewBag.OPGId = opgId;
        ViewBag.VrstaUslugeList = new SelectList(_context.VrsteUsluga, "Id", "Naziv", usluga.VrstaUslugeId);
        return View(usluga);
    }

    // GET: MojOPG/EditStrojAlat/5
    public IActionResult EditStrojAlat(int id, int opgId)
    {
        var strojAlat = _context.StrojeviAlati.FirstOrDefault(sa => sa.Id == id);
        if (strojAlat == null)
        {
            return NotFound();
        }

        ViewBag.OPGId = opgId;
        ViewBag.VrstaStrojaAlataList = new SelectList(_context.VrsteStrojevaAlata, "Id", "Naziv", strojAlat.VrstaStrojaAlataId);
        return View(strojAlat);
    }

    // POST: MojOPG/EditStrojAlat/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult EditStrojAlat(StrojAlat strojAlat, int opgId)
    {
        ModelState.Remove(nameof(strojAlat.VrstaStrojaAlata));
        if (ModelState.IsValid)
        {
            _context.Update(strojAlat);
            _context.SaveChanges();

            return RedirectToAction("Edit", new { id = opgId, activeTab = "strojeviAlati" });
        }

        ViewBag.OPGId = opgId;
        ViewBag.VrstaStrojaAlataList = new SelectList(_context.VrsteStrojevaAlata, "Id", "Naziv", strojAlat.VrstaStrojaAlataId);
        return View(strojAlat);
    }

    public IActionResult CreateImanjeVlasnik(int opgId)
    {
        ViewBag.OPGId = opgId;
        ViewBag.Vlasnici = new SelectList(_context.Vlasnici, "Id", "Ime");
        ViewBag.Imanja = new SelectList(_context.Imanja, "Id", "Katastar");
        ViewBag.Proizvodi = new SelectList(_context.Proizvodi, "Id", "Naziv");

        return View(new ImanjeVlasnik());
    }

    [HttpPost]
    public IActionResult CreateImanjeVlasnik(ImanjeVlasnik imanjeVlasnik, int opgId)
    {
        if (ModelState.IsValid)
        {
            _context.ImanjaVlasnici.Add(imanjeVlasnik);
            _context.SaveChanges();

            return RedirectToAction("Edit", new { id = opgId, activeTab = "imanjaVlasnika" });
        }

        ViewBag.OPGId = opgId;
        ViewBag.Vlasnici = new SelectList(_context.Vlasnici, "Id", "Ime");
        ViewBag.Imanja = new SelectList(_context.Imanja, "Id", "Katastar");
        ViewBag.Proizvodi = new SelectList(_context.Proizvodi, "Id", "Naziv");

        return View(imanjeVlasnik);
    }

    public IActionResult EditImanjeVlasnik(int id, int opgId)
    {
        var imanjeVlasnik = _context.ImanjaVlasnici.Find(id);
        if (imanjeVlasnik == null)
        {
            return NotFound();
        }

        ViewBag.OPGId = opgId;
        ViewBag.Vlasnici = new SelectList(_context.Vlasnici, "Id", "Ime", imanjeVlasnik.VlasnikId);
        ViewBag.Imanja = new SelectList(_context.Imanja, "Id", "Katastar", imanjeVlasnik.ImanjeId);
        ViewBag.Proizvodi = new SelectList(_context.Proizvodi, "Id", "Naziv", imanjeVlasnik.ProizvodId);

        return View(imanjeVlasnik);
    }

    [HttpPost]
    public IActionResult EditImanjeVlasnik(ImanjeVlasnik imanjeVlasnik, int opgId)
    {
        if (ModelState.IsValid)
        {
            _context.Update(imanjeVlasnik);
            _context.SaveChanges();

            return RedirectToAction("Edit", new { id = opgId, activeTab = "imanjaVlasnika" });
        }

        ViewBag.OPGId = opgId;
        ViewBag.Vlasnici = new SelectList(_context.Vlasnici, "Id", "Ime", imanjeVlasnik.VlasnikId);
        ViewBag.Imanja = new SelectList(_context.Imanja, "Id", "Katastar", imanjeVlasnik.ImanjeId);
        ViewBag.Proizvodi = new SelectList(_context.Proizvodi, "Id", "Naziv", imanjeVlasnik.ProizvodId);

        return View(imanjeVlasnik);
    }

    [HttpPost]
    public IActionResult DeleteImanjeVlasnik(int id, int opgId)
    {
        var imanjeVlasnik = _context.ImanjaVlasnici.Find(id);
        if (imanjeVlasnik == null)
        {
            return NotFound();
        }

        _context.ImanjaVlasnici.Remove(imanjeVlasnik);
        _context.SaveChanges();

        return RedirectToAction("Edit", new { id = opgId, activeTab = "imanjaVlasnika" });
    }


}



