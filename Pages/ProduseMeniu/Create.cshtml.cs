using GestiuneRestaurant.Data;
using GestiuneRestaurant.Models;
using GestiuneRestaurant.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestiuneRestaurant.Pages.ProduseMeniu
{
    public class CreateModel : RestaurantPageModel
    {
        private readonly GestiuneRestaurant.Data.GestiuneRestaurantContext _context;

        public CreateModel(GestiuneRestaurant.Data.GestiuneRestaurantContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ProdusMeniu ProdusMeniu { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ProdusMeniu.Add(ProdusMeniu);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
