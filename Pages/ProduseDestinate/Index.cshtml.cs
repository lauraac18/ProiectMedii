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
    public class IndexModel : PageModel
    {
        private readonly GestiuneRestaurant.Data.GestiuneRestaurantContext _context;

        public IndexModel(GestiuneRestaurant.Data.GestiuneRestaurantContext context)
        {
            _context = context;
        }

        public IList<ProdusDestinat> ProdusDestinat { get;set; } = default!;

        public async Task OnGetAsync()
        {
            ProdusDestinat = await _context.ProdusDestinat
                .Include(p => p.CategorieProdus)
                .Include(p => p.ProdusMeniu).ToListAsync();
        }
    }
}
