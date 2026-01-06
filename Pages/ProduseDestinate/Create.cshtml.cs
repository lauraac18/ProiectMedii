using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GestiuneRestaurant.Models;
using GestiuneRestaurant.Data;
using System.Threading.Tasks;

namespace GestiuneRestaurant.Pages.ProduseDestinate
{
    public class CreateModel : PageModel
    {
        private readonly GestiuneRestaurantContext _context;

        public CreateModel(GestiuneRestaurantContext context)
        {
            _context = context;
        }

       
        [BindProperty]
        public ProdusDestinat ProdusDestinat { get; set; } = default!;

        public IActionResult OnGet()
        {
            // Verifică dacă în tabelele tale coloanele de afișat sunt NumePreparat și NumeCategorie
            ViewData["ProdusMeniuID"] = new SelectList(_context.ProdusMeniu, "ID", "NumePreparat");
            ViewData["CategorieProdusID"] = new SelectList(_context.CategorieProdus, "ID", "NumeCategorie");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ProdusDestinat.Add(ProdusDestinat);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}