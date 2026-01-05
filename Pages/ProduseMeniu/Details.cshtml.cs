using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GestiuneRestaurant.Data;
using ProiectRestaurant.Models;

namespace GestiuneRestaurant.Pages.ProduseMeniu
{
    public class DetailsModel : PageModel
    {
        private readonly GestiuneRestaurant.Data.GestiuneRestaurantContext _context;

        public DetailsModel(GestiuneRestaurant.Data.GestiuneRestaurantContext context)
        {
            _context = context;
        }

        public ProdusMeniu ProdusMeniu { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produsmeniu = await _context.ProdusMeniu.FirstOrDefaultAsync(m => m.ID == id);
            if (produsmeniu == null)
            {
                return NotFound();
            }
            else
            {
                ProdusMeniu = produsmeniu;
            }
            return Page();
        }
    }
}
