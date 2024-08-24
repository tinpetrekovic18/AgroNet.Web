using AgroNet.DAL;
using AgroNet.Model;
using AgroNet.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AgroNet.Web.Controllers
{
    public class OPGController : Controller
    {
        private readonly AgroNetDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public OPGController(AgroNetDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult OPG(OPGFilterModel filter)
        {
            ViewBag.Zupanije = new SelectList(_context.Zupanije, "Id", "Naziv");

            filter ??= new OPGFilterModel();

            var opgQuery = _context.OPGs
                .Include(o => o.Mjesto)
                .Include(o => o.Mjesto.Zupanija)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(filter.NazivOPG))
                opgQuery = opgQuery.Where(o => o.Naziv.ToLower().Contains(filter.NazivOPG.ToLower()));

            if (!string.IsNullOrWhiteSpace(filter.NazivMjesta))
                opgQuery = opgQuery.Where(o => o.Mjesto.Naziv.ToLower().Contains(filter.NazivMjesta.ToLower()));

            if (filter.ZupanijaId != null)
                opgQuery = opgQuery.Where(o => o.Mjesto.Zupanija.Id == filter.ZupanijaId);

            var model = opgQuery.ToList();
            return View(model);
        }

        public IActionResult Details(int id)
        {
            var opg = _context.OPGs
                .Include(o => o.Mjesto)
                .Include(o => o.Mjesto.Zupanija)
                .FirstOrDefault(o => o.Id == id);

            if (opg == null)
            {
                return NotFound();
            }

            // Fetch the Vlasnici related to the OPG
            var vlasnici = _context.VlasniciOPG
                .Where(vo => vo.OPGId == opg.Id)
                .Include(vo => vo.Vlasnik)
                .Select(vo => vo.Vlasnik)
                .ToList();

            var djelatnost = _context.DjelatnostiOPG
                .Where(dj => dj.OPGId == opg.Id)
                .Include(dj => dj.Djelatnost)
                .Select(dj => dj.Djelatnost)
                .FirstOrDefault();

            // Fetch the Usluge related to the OPG
            var usluge = _context.OPGUsluge
                .Where(u => u.OPGId == opg.Id)
                .Include(u => u.Usluga)
                .Include(u => u.Usluga.VrstaUsluge)
                .ToList();

            // Fetch the Proizvodi related to the OPG
            var proizvodi = _context.OPGProizvodi
                .Where(p => p.OPGId == opg.Id)
                .Include(p => p.Proizvod)
                .Include(p => p.Proizvod.VrstaProizvoda)
                .ToList();

            // Fetch the StrojeviAlati related to the OPG
            var strojeviAlati = _context.OPGStrojeviAlati
                .Where(sa => sa.OPGId == opg.Id)
                .Include(sa => sa.StrojAlat)
                .Include(sa => sa.StrojAlat.VrstaStrojaAlata)
                .ToList();

            var model = new OPGDetailsViewModel
            {
                OPG = opg,
                Vlasnici = vlasnici,
                Djelatnost =djelatnost,
                Usluge = usluge,
                Proizvodi = proizvodi,
                StrojeviAlati = strojeviAlati
            };

            return View(model);
        }

    }
}
