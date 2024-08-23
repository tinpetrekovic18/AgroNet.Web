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



    }
}
