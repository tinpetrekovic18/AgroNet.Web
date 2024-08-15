using Microsoft.AspNetCore.Mvc;
using AgroNet.DAL;
using AgroNet.Model;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;
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

    // GET: MojOPG/Edit
    public IActionResult Edit(int id)
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

        var opg = _context.OPGs.FirstOrDefault(o => o.Id == id && _context.VlasniciOPG.Any(vo => vo.OPGId == o.Id && vo.VlasnikId == vlasnik.Id));
        if (opg == null)
        {
            return NotFound();
        }

        var djelatnostId = _context.DjelatnostiOPG
            .Where(d => d.OPGId == id)
            .Select(d => d.DjelatnostId)
            .FirstOrDefault();

        ViewBag.Mjesta = new SelectList(_context.Mjesta, "Id", "Naziv", opg.MjestoId);
        ViewBag.Djelatnosti = new SelectList(_context.Djelatnosti, "Id", "Naziv", djelatnostId);
        ViewBag.IsEditMode = true;
        return View("Edit", opg);
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



