using System.ComponentModel.DataAnnotations;

namespace ProiectRestaurant.Models
{
    public class Client
    {
        public int ID { get; set; }

        [RegularExpression(@"^[A-Z][a-z]*$", ErrorMessage = "Numele trebuie sa inceapa cu majuscula")]
        public string Nume { get; set; }

        [RegularExpression(@"^[A-Z][a-z]*$", ErrorMessage = "Prenumele trebuie sa inceapa cu majuscula")]
        public string Prenume { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        [RegularExpression(@"^\(?([0-9]{4})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{3})$", ErrorMessage = "Telefonul trebuie sa fie de forma '0722-123-123'")]
        public string? Telefon { get; set; }

        [Display(Name = "Nume Complet")]
        public string NumeComplet => Nume + " " + Prenume;

        public ICollection<Rezervare>? Rezervari { get; set; }
    }
}