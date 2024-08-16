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

    public IActionResult Edit(int id)
    {
        var opg = _context.OPGs
            .Include(o => o.Mjesto)
            .FirstOrDefault(o => o.Id == id);

        if (opg == null)
        {
            return NotFound();
        }

        // Fetch the linked DjelatnostId
        var linkedDjelatnost = _context.DjelatnostiOPG
            .FirstOrDefault(d => d.OPGId == id);
        int? selectedDjelatnostId = linkedDjelatnost?.DjelatnostId;

        ViewBag.Mjesta = new SelectList(_context.Mjesta, "Id", "Naziv", opg.MjestoId);
        ViewBag.Djelatnosti = new SelectList(_context.Djelatnosti, "Id", "Naziv", selectedDjelatnostId); // Set the selected item
        ViewBag.Proizvodi = _context.OPGProizvodi
            .Where(op => op.OPGId == id)
            .Select(op => op.Proizvod)
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

            return RedirectToAction("Edit", new { id = opgId });
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
}



