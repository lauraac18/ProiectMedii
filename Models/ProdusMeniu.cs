using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestiuneRestaurant.Models
{
    public class ProdusMeniu
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Numele preparatului este obligatoriu")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Numele trebuie să aibă între 3 și 100 de caractere")]
        [Display(Name = "Nume Preparat")]
        public string NumePreparat { get; set; }

        [Column(TypeName = "decimal(6, 2)")]
        [Range(0.01, 1000, ErrorMessage = "Prețul trebuie să fie între 0.01 și 1000 RON")]
        [DataType(DataType.Currency)]
        [Display(Name = "Preț Unitar")]
        public decimal Pret { get; set; }

        [StringLength(200, ErrorMessage = "Descrierea nu poate depăși 200 de caractere")]
        [Display(Name = "Descriere Produs")]
        public string? Descriere { get; set; }

        
        [Display(Name = "Categorii Destinate")]
        public ICollection<ProdusDestinat>? ProduseDestinate { get; set; }
    }
}