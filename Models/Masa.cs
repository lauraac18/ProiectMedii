using System.ComponentModel.DataAnnotations;

namespace ProiectRestaurant.Models
{
    public class Masa
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "Număr Masă")]
        public int NumarMasa { get; set; }

        [Range(1, 20)]
        public int Capacitate { get; set; }

        public ICollection<Rezervare>? Rezervari { get; set; }
    }
}
