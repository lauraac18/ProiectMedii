using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GestiuneRestaurant.Data;
using GestiuneRestaurant.Models;

namespace GestiuneRestaurant.Pages.ProduseMeniu
{
    public class IndexModel : PageModel
    {
        private readonly GestiuneRestaurant.Data.GestiuneRestaurantContext _context;

        public IndexModel(GestiuneRestaurant.Data.GestiuneRestaurantContext context)
        {
            _context = context;
        }

        public IList<ProdusMeniu> ProdusMeniu { get; set; } = default!;
        public string NameSort { get; set; }
        public string PriceSort { get; set; }
        public string CurrentSort { get; set; }

        public async Task OnGetAsync(string sortOrder, string searchString)
        {
            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            PriceSort = sortOrder == "Pret" ? "price_desc" : "Pret";

            IQueryable<ProdusMeniu> produseIQ = _context.ProdusMeniu
                .Include(p => p.ProduseDestinate)
                .ThenInclude(p => p.CategorieProdus);

            if (!String.IsNullOrEmpty(searchString))
            {
                produseIQ = produseIQ.Where(s => s.NumePreparat.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    produseIQ = produseIQ.OrderByDescending(s => s.NumePreparat);
                    break;
                case "Pret":
                    produseIQ = produseIQ.OrderBy(s => s.Pret);
                    break;
                case "price_desc":
                    produseIQ = produseIQ.OrderByDescending(s => s.Pret);
                    break;
                default:
                    produseIQ = produseIQ.OrderBy(s => s.NumePreparat);
                    break;
            }

            ProdusMeniu = await produseIQ.AsNoTracking().ToListAsync();
        }
    }
}