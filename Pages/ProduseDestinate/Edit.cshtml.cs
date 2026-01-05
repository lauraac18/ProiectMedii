using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GestiuneRestaurant.Data;
using ProiectRestaurant.Models;

namespace GestiuneRestaurant.Pages.ProduseDestinate
{
    public class EditModel : PageModel
    {
        private readonly GestiuneRestaurant.Data.GestiuneRestaurantContext _context;

        public EditModel(GestiuneRestaurant.Data.GestiuneRestaurantContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ProdusDestinat ProdusDestinat { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produsdestinat =  await _context.ProdusDestinat.FirstOrDefaultAsync(m => m.ID == id);
            if (produsdestinat == null)
            {
                return NotFound();
            }
            ProdusDestinat = produsdestinat;
           ViewData["CategorieProdusID"] = new SelectList(_context.Set<CategorieProdus>(), "ID", "NumeCategorie");
           ViewData["ProdusMeniuID"] = new SelectList(_context.ProdusMeniu, "ID", "NumePreparat");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ProdusDestinat).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProdusDestinatExists(ProdusDestinat.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ProdusDestinatExists(int id)
        {
            return _context.ProdusDestinat.Any(e => e.ID == id);
        }
    }
}
