using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GestiuneRestaurant.Data;
using GestiuneRestaurant.Models;

namespace GestiuneRestaurant.Pages.ProduseDestinate
{
    public class DetailsModel : PageModel
    {
        private readonly GestiuneRestaurant.Data.GestiuneRestaurantContext _context;

        public DetailsModel(GestiuneRestaurant.Data.GestiuneRestaurantContext context)
        {
            _context = context;
        }

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
    }
}
