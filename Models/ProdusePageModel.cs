using Microsoft.AspNetCore.Mvc.RazorPages;
using GestiuneRestaurant.Data;
using ProiectRestaurant.Models;

namespace GestiuneRestaurant.Models
{
    public class ProdusePageModel : PageModel
    {
        public List<AssignedCategoryData> AssignedCategoryDataList;

        public void PopulateAssignedCategoryData(GestiuneRestaurantContext context, ProdusMeniu produs)
        {
            var allCategories = context.CategorieProdus;
            var produsCategories = new HashSet<int>(
                produs.ProduseDestinate.Select(c => c.CategorieProdusID));

            AssignedCategoryDataList = new List<AssignedCategoryData>();
            foreach (var cat in allCategories)
            {
                AssignedCategoryDataList.Add(new AssignedCategoryData
                {
                    CategoryID = cat.ID,
                    Name = cat.NumeCategorie,
                    Assigned = produsCategories.Contains(cat.ID)
                });
            }
        }

        public void UpdateProduseCategories(GestiuneRestaurantContext context,
            string[] selectedCategories, ProdusMeniu produsToUpdate)
        {
            if (selectedCategories == null)
            {
                produsToUpdate.ProduseDestinate = new List<ProdusDestinat>();
                return;
            }

            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var produsCategories = new HashSet<int>
                (produsToUpdate.ProduseDestinate.Select(c => c.CategorieProdus.ID));

            foreach (var cat in context.CategorieProdus)
            {
                if (selectedCategoriesHS.Contains(cat.ID.ToString()))
                {
                    if (!produsCategories.Contains(cat.ID))
                    {
                        produsToUpdate.ProduseDestinate.Add(
                            new ProdusDestinat
                            {
                                ProdusMeniuID = produsToUpdate.ID,
                                CategorieProdusID = cat.ID
                            });
                    }
                }
                else
                {
                    if (produsCategories.Contains(cat.ID))
                    {
                        ProdusDestinat courseToRemove = produsToUpdate.ProduseDestinate
                            .SingleOrDefault(i => i.CategorieProdusID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}