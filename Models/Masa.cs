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

        [Required(ErrorMessage = "Numărul mesei este obligatoriu")]
        [Display(Name = "Număr Masă")]
        [Range(1, 100, ErrorMessage = "Numărul mesei trebuie să fie între 1 și 100")]
        public int NumarMasa { get; set; }

        [Required(ErrorMessage = "Capacitatea mesei trebuie specificată")]
        [Range(1, 20, ErrorMessage = "O masă poate avea între 1 și 20 de locuri")]
        [Display(Name = "Capacitate (Persoane)")]
        public int Capacitate { get; set; }

        [Display(Name = "Stare Actuală")]
        public StareMasa Stare { get; set; } = StareMasa.Libera;

        // Relația cu Rezervările
        public ICollection<Rezervare>? Rezervari { get; set; }
    }
}