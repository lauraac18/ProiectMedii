using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProiectRestaurant.Models
{
    public class ProdusMeniu
    {
        public int ID { get; set; }

        [Required, StringLength(100, MinimumLength = 3)]
        [Display(Name = "Nume Preparat")]
        public string NumePreparat { get; set; }

        [Column(TypeName = "decimal(6, 2)")]
        [Range(0.01, 1000)]
        public decimal Pret { get; set; }

        public string? Descriere { get; set; }

        public ICollection<ProdusDestinat>? ProduseDestinate { get; set; }
    }
}