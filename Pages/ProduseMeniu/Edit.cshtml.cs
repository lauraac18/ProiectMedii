using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestiuneRestaurant.Models;

public class EditModel : ProdusePageModel 
{
    private readonly GestiuneRestaurant.Data.GestiuneRestaurantContext _context;
    public EditModel(GestiuneRestaurant.Data.GestiuneRestaurantContext context) { _context = context; }

    [BindProperty]
    public ProdusMeniu ProdusMeniu { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null) return NotFound();

        ProdusMeniu = await _context.ProdusMeniu
            .Include(b => b.ProduseDestinate).ThenInclude(b => b.CategorieProdus)
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.ID == id);

        if (ProdusMeniu == null) return NotFound();

        PopulateAssignedCategoryData(_context, ProdusMeniu);
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? id, string[] selectedCategories)
    {
        if (id == null) return NotFound();

        var produsToUpdate = await _context.ProdusMeniu
            .Include(i => i.ProduseDestinate).ThenInclude(i => i.CategorieProdus)
            .FirstOrDefaultAsync(s => s.ID == id);

        if (produsToUpdate == null) return NotFound();

        if (await TryUpdateModelAsync<ProdusMeniu>(produsToUpdate, "ProdusMeniu",
            i => i.NumePreparat, i => i.Pret, i => i.Descriere))
        {
            UpdateProduseCategories(_context, selectedCategories, produsToUpdate);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }

        UpdateProduseCategories(_context, selectedCategories, produsToUpdate);
        PopulateAssignedCategoryData(_context, produsToUpdate);
        return Page();
    }
}