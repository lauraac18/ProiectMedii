using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GestiuneRestaurant.Data;
using GestiuneRestaurant.Models;

namespace GestiuneRestaurant.Pages.CategoriiProdus
{
    public class DetailsModel : PageModel
    {
        private readonly GestiuneRestaurant.Data.GestiuneRestaurantContext _context;

        public DetailsModel(GestiuneRestaurant.Data.GestiuneRestaurantContext context)
        {
            _context = context;
        }

        public CategorieProdus CategorieProdus { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categorieprodus = await _context.CategorieProdus.FirstOrDefaultAsync(m => m.ID == id);
            if (categorieprodus == null)
            {
                return NotFound();
            }
            else
            {
                CategorieProdus = categorieprodus;
            }
            return Page();
        }
    }
}
