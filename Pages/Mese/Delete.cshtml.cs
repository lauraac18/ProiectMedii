using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GestiuneRestaurant.Data;
using GestiuneRestaurant.Models;

namespace GestiuneRestaurant.Pages.Mese
{
    public class DeleteModel : PageModel
    {
        private readonly GestiuneRestaurant.Data.GestiuneRestaurantContext _context;

        public DeleteModel(GestiuneRestaurant.Data.GestiuneRestaurantContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Masa Masa { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var masa = await _context.Masa.FirstOrDefaultAsync(m => m.ID == id);

            if (masa == null)
            {
                return NotFound();
            }
            else
            {
                Masa = masa;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var masa = await _context.Masa.FindAsync(id);
            if (masa != null)
            {
                Masa = masa;
                _context.Masa.Remove(Masa);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
