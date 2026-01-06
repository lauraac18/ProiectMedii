using System.ComponentModel.DataAnnotations;

namespace GestiuneRestaurant.Models
{
    public enum StareMasa
    {
        Libera,
        Ocupata,
        Rezervata
    }
    public class Masa
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "Număr Masă")]
        public int NumarMasa { get; set; }

        [Range(1, 20)]
        public int Capacitate { get; set; }

        public StareMasa Stare { get; set; } = StareMasa.Libera;
        public ICollection<Rezervare>? Rezervari { get; set; }
    }
}
