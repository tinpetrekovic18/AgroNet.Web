using AgroNet.DAL;
using AgroNet.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Usluge()
        {
            // Fetch all Usluga items from the database
            var usluge = _context.Usluge
                .Include(u => u.VrstaUsluge) // Include related VrstaUsluge
                .ToList();

            return View(usluge);
        }
    }
}
