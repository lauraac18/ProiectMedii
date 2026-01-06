using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GestiuneRestaurant.Data;
using GestiuneRestaurant.Models;

namespace GestiuneRestaurant.Pages.Rezervari
{
    public class CreateModel : PageModel
    {
        private readonly GestiuneRestaurant.Data.GestiuneRestaurantContext _context;

        public CreateModel(GestiuneRestaurant.Data.GestiuneRestaurantContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            RepopulateDropdowns();
            return Page();
        }

        [BindProperty]
        public Rezervare Rezervare { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                RepopulateDropdowns();
                return Page();
            }

            if (Rezervare.DataOra < DateTime.Now)
            {
                ModelState.AddModelError("Rezervare.DataOra", "Data rezervării nu poate fi în trecut.");
                RepopulateDropdowns();
                return Page();
            }
            var masaSelectata = await _context.Masa.FindAsync(Rezervare.MasaID);
            if (masaSelectata != null && Rezervare.NumarPersoane > masaSelectata.Capacitate)
            {
                ModelState.AddModelError("Rezervare.NumarPersoane",
                    $"Capacitatea maximă pentru Masa {masaSelectata.NumarMasa} este de {masaSelectata.Capacitate} persoane.");
                RepopulateDropdowns();
                return Page();
            }
            DateTime startInterval = Rezervare.DataOra.AddHours(-2);
            DateTime endInterval = Rezervare.DataOra.AddHours(2);

            bool masaOcupata = await _context.Rezervare.AnyAsync(r =>
                r.MasaID == Rezervare.MasaID &&
                r.DataOra > startInterval &&
                r.DataOra < endInterval);

            if (masaOcupata)
            {
                ModelState.AddModelError("Rezervare.MasaID", "Masa este deja rezervată pentru acest interval orar.");
                RepopulateDropdowns();
                return Page();
            }

            try
            {
                _context.Rezervare.Add(Rezervare);
                if (masaSelectata != null)
                {
                    masaSelectata.Stare = StareMasa.Rezervata;
                    _context.Masa.Update(masaSelectata);
                }

                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Rezervarea a fost creată cu succes!";
                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Eroare de sistem: " + ex.Message);
                RepopulateDropdowns();
                return Page();
            }
        }

        private void RepopulateDropdowns()
        {
            ViewData["ClientID"] = new SelectList(_context.Set<Client>(), "ID", "NumeComplet");
            ViewData["MasaID"] = new SelectList(_context.Set<Masa>(), "ID", "NumarMasa");
        }
    }
}