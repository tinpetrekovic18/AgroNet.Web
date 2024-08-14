using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using AgroNet.DAL;
using AgroNet.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AgroNet.Web.Areas.Identity.Pages.Account.Manage
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly AgroNetDbContext _context;

        public IndexModel(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            AgroNetDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        public string Username { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Phone]
            [Display(Name = "Broj mobitela")]
            public string BrojMobitela { get; set; }

            [Display(Name = "OIB")]
            public string OIB { get; set; }

            [Display(Name = "Adresa")]
            public string Adresa { get; set; }

            [Display(Name = "PostanskiBroj")]
            public string PostanskiBroj { get; set; }

            [Display(Name = "Županija")]
            public int ZupanijaId { get; set; }  // Add this property


        }

        private async Task LoadAsync(AppUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            var vlasnik = await _context.Vlasnici
                .Include(v => v.MjestoPrebivalista) // Ensure MjestoPrebivalista is loaded
                .FirstOrDefaultAsync(v => v.Id == user.VlasnikId);

            Username = userName;

            Input = new InputModel
            {
                BrojMobitela = phoneNumber,
                OIB = vlasnik?.OIB,
                Adresa = vlasnik?.MjestoPrebivalista?.Naziv,
                ZupanijaId = vlasnik?.MjestoPrebivalista?.ZupanijaId ?? 0, // Use 0 or an appropriate default value
                PostanskiBroj = vlasnik?.MjestoPrebivalista?.PostanskiBroj.ToString() ?? string.Empty // Handle null case
            };
        }


        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);

            var vlasnik = await _context.Vlasnici.Include(v => v.MjestoPrebivalista)
                                                 .FirstOrDefaultAsync(v => v.Id == user.VlasnikId);

            if (vlasnik != null && vlasnik.MjestoPrebivalista != null)
            {
                ViewData["MjestoNaziv"] = vlasnik.MjestoPrebivalista.Naziv;
            }

            InitiateSelectZupanija();
            return Page();
        }


        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                InitiateSelectZupanija();
                return Page();
            }

            // Check if Mjesto already exists based on the provided data
            var existingMjesto = await _context.Mjesta
                .FirstOrDefaultAsync(m => m.Naziv == Input.Adresa && m.PostanskiBroj == int.Parse(Input.PostanskiBroj) && m.ZupanijaId == Input.ZupanijaId);

            if (existingMjesto == null)
            {
                // If Mjesto doesn't exist, create a new one
                var newMjesto = new Mjesto
                {
                    Naziv = Input.Adresa,
                    PostanskiBroj = int.Parse(Input.PostanskiBroj),
                    ZupanijaId = Input.ZupanijaId
                };
                _context.Mjesta.Add(newMjesto);
                await _context.SaveChangesAsync();

                existingMjesto = newMjesto; // Assign the newly created Mjesto to the existingMjesto variable
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.BrojMobitela != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.BrojMobitela);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to set phone number.";
                    return RedirectToPage();
                }
            }

            var vlasnik = await _context.Vlasnici.FirstOrDefaultAsync(v => v.Id == user.VlasnikId);
            if (vlasnik == null)
            {
                // If Vlasnik doesn't exist, create a new one
                vlasnik = new Vlasnik
                {
                    OIB = Input.OIB,
                    MjestoPrebivalistaId = existingMjesto.Id, // Set the Mjesto ID
                    BrojTelefona = Input.BrojMobitela,
                    Email = user.Email // Assuming the email is the user's email
                };
                _context.Vlasnici.Add(vlasnik);
                await _context.SaveChangesAsync();

                user.VlasnikId = vlasnik.Id;
                await _userManager.UpdateAsync(user);
            }
            else
            {
                // Update the existing Vlasnik
                vlasnik.OIB = Input.OIB;
                vlasnik.MjestoPrebivalistaId = existingMjesto.Id; // Update Mjesto ID if necessary
                vlasnik.BrojTelefona = Input.BrojMobitela;
                _context.Vlasnici.Update(vlasnik);
                await _context.SaveChangesAsync();
            }

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }

        public void InitiateSelectZupanija()
        {
            var zupanije = new List<SelectListItem>();

            var listItem = new SelectListItem
            {
                Text = " Odaberite županiju ",
                Value = ""
            };
            zupanije.Add(listItem);

            foreach (var zupanija in _context.Zupanije)
            {
                listItem = new SelectListItem
                {
                    Text = zupanija.Naziv,
                    Value = zupanija.Id.ToString()
                };
                zupanije.Add(listItem);
            }

            ViewData["Zupanije"] = zupanije;
        }
    }
}