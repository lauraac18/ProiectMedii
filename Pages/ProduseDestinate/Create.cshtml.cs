using Microsoft.AspNetCore.Mvc;
using ProiectRestaurant.Models;

public class CreateModel : ProdusePageModel 
{
    private readonly GestiuneRestaurant.Data.GestiuneRestaurantContext _context;
    public CreateModel(GestiuneRestaurant.Data.GestiuneRestaurantContext context) { _context = context; }

    public IActionResult OnGet()
    {
        var produs = new ProdusMeniu();
        produs.ProduseDestinate = new List<ProdusDestinat>();
        PopulateAssignedCategoryData(_context, produs);
        return Page();
    }

    [BindProperty]
    public ProdusMeniu ProdusMeniu { get; set; } = default!;

    public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
    {
        var noulProdus = new ProdusMeniu();
        if (selectedCategories != null)
        {
            noulProdus.ProduseDestinate = new List<ProdusDestinat>();
            foreach (var cat in selectedCategories)
            {
                noulProdus.ProduseDestinate.Add(new ProdusDestinat { CategorieProdusID = int.Parse(cat) });
            }
        }

        if (await TryUpdateModelAsync<ProdusMeniu>(noulProdus, "ProdusMeniu",
            i => i.NumePreparat, i => i.Pret, i => i.Descriere))
        {
            _context.ProdusMeniu.Add(noulProdus);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }

        PopulateAssignedCategoryData(_context, noulProdus);
        return Page();
    }
}