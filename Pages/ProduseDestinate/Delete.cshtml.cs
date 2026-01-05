using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GestiuneRestaurant.Data;
using ProiectRestaurant.Models;

namespace GestiuneRestaurant.Pages.ProduseDestinate
{
    public class DeleteModel : PageModel
    {
        private readonly GestiuneRestaurant.Data.GestiuneRestaurantContext _context;

        public DeleteModel(GestiuneRestaurant.Data.GestiuneRestaurantContext context)
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

            var produsdestinat = await _context.ProdusDestinat.FirstOrDefaultAsync(m => m.ID == id);

            if (produsdestinat == null)
            {
                return NotFound();
            }
            else
            {
                ProdusDestinat = produsdestinat;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produsdestinat = await _context.ProdusDestinat.FindAsync(id);
            if (produsdestinat != null)
            {
                ProdusDestinat = produsdestinat;
                _context.ProdusDestinat.Remove(ProdusDestinat);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
