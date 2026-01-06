using Microsoft.AspNetCore.Mvc.RazorPages;
using GestiuneRestaurant.Data;
using GestiuneRestaurant.Models;
using GestiuneRestaurant.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace GestiuneRestaurant.Models
{
    public class RestaurantPageModel : PageModel
    {
        public List<AssignedCategoryData> AssignedCategoryDataList;

        public void PopulateAssignedCategoryData(GestiuneRestaurantContext context, ProdusMeniu produs)
        {
            var allCategories = context.CategorieProdus;

            // SCHIMBARE: Folosim .ProduseDestinate (numele din modelul tau)
            var produsCategories = new HashSet<int>(
                produs.ProduseDestinate != null
                ? produs.ProduseDestinate.Select(c => c.CategorieProdusID)
                : new List<int>());

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

        public void UpdateProductCategories(GestiuneRestaurantContext context,
            string[] selectedCategories, ProdusMeniu produsToUpdate)
        {
            if (selectedCategories == null)
            {
                // SCHIMBARE: Folosim .ProduseDestinate
                produsToUpdate.ProduseDestinate = new List<ProdusDestinat>();
                return;
            }

            var selectedCategoriesHS = new HashSet<string>(selectedCategories);

            // SCHIMBARE: Folosim .ProduseDestinate si clasa ProdusDestinat
            var productCategories = new HashSet<int>
                (produsToUpdate.ProduseDestinate.Select(c => c.CategorieProdus.ID));

            foreach (var cat in context.CategorieProdus)
            {
                if (selectedCategoriesHS.Contains(cat.ID.ToString()))
                {
                    if (!productCategories.Contains(cat.ID))
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
                    if (productCategories.Contains(cat.ID))
                    {
                        ProdusDestinat categoryToRemove = produsToUpdate
                            .ProduseDestinate
                            .SingleOrDefault(i => i.CategorieProdusID == cat.ID);
                        context.Remove(categoryToRemove);
                    }
                }
            }
        }
    }
}