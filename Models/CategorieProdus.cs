using System.ComponentModel.DataAnnotations;

namespace GestiuneRestaurant.Models
{
    public class CategorieProdus
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "Nume Categorie")]
        public string NumeCategorie { get; set; }
        public ICollection<ProdusDestinat>? ProduseDestinate { get; set; }
    }
}