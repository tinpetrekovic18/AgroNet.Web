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
        var userEmail = User.Identity.Name;  // Get the email of the logged-in user
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
            // The user already has an OPG, redirect to the Edit view
            return RedirectToAction("Edit", new { id = vlasnikOpg.OPGId });
        }

        // If the user does not have an OPG, show the create form
        ViewBag.Mjesta = new SelectList(_context.Mjesta, "Id", "Naziv");
        return View("Create");
    }

    // POST: MojOPG/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(OPG opg)
    {
        var userEmail = User.Identity.Name;  // Get the email of the logged-in user
        if (userEmail == null)
        {
            return Unauthorized("User is not logged in.");
        }

        var vlasnik = _context.Vlasnici.FirstOrDefault(v => v.Email == userEmail);

        if (vlasnik == null)
        {
            return NotFound("Vlasnik not found.");
        }

        // Check if the user already has an OPG
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

            // Create the VlasnikOPG link
            var vlasnikOpg = new VlasnikOPG
            {
                VlasnikId = vlasnik.Id,
                OPGId = opg.Id
            };

            _context.VlasniciOPG.Add(vlasnikOpg);
            _context.SaveChanges();

            return RedirectToAction("CreateOrEdit"); // Redirect to the edit form
        }

        ViewBag.Mjesta = new SelectList(_context.Mjesta, "Id", "Naziv", opg.MjestoId);
        return View(opg);
    }

    // GET: MojOPG/Edit
    public IActionResult Edit(int id)
    {
        var userEmail = User.Identity.Name;  // Get the email of the logged-in user
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

        ViewBag.Mjesta = new SelectList(_context.Mjesta, "Id", "Naziv", opg.MjestoId);
        return View("Edit", opg); // Redirect to Edit.cshtml
    }

    // POST: MojOPG/Edit
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(OPG opg)
    {
        var userEmail = User.Identity.Name;  // Get the email of the logged-in user
        if (userEmail == null)
        {
            return Unauthorized("User is not logged in.");
        }

        var vlasnik = _context.Vlasnici.FirstOrDefault(v => v.Email == userEmail);

        if (vlasnik == null)
        {
            return NotFound("Vlasnik not found.");
        }

        // Check if the OPG belongs to the current user
        if (!_context.VlasniciOPG.Any(vo => vo.OPGId == opg.Id && vo.VlasnikId == vlasnik.Id))
        {
            return Unauthorized();
        }

        ModelState.Remove(nameof(opg.Mjesto));
        if (ModelState.IsValid)
        {
            _context.Update(opg);
            _context.SaveChanges();
            return RedirectToAction("CreateOrEdit"); // Redirect back to the edit form
        }

        ViewBag.Mjesta = new SelectList(_context.Mjesta, "Id", "Naziv", opg.MjestoId);
        return View("Edit", opg);
    }
}
