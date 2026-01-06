using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
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
           

            ViewData["ClientID"] = new SelectList(_context.Set<Client>(), "ID", "NumeComplet");

            ViewData["MasaID"] = new SelectList(_context.Set<Masa>(), "ID", "NumarMasa");

            return Page();
        }

        [BindProperty]
        public Rezervare Rezervare { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

           
            _context.Rezervare.Add(Rezervare);
            await _context.SaveChangesAsync();

        
            var masaRezervata = await _context.Masa.FindAsync(Rezervare.MasaID);

            if (masaRezervata != null)
            {
               
                masaRezervata.Stare = StareMasa.Rezervata;

               
                _context.Masa.Update(masaRezervata);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
