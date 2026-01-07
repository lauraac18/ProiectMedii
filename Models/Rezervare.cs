using System.ComponentModel.DataAnnotations;

namespace GestiuneRestaurant.Models
{
    public class Rezervare
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Data și ora sunt obligatorii")]
        [Display(Name = "Data și Ora Rezervării")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime DataOra { get; set; }

        [Required(ErrorMessage = "Numărul de persoane este obligatoriu")]
        [Range(1, 20, ErrorMessage = "Numărul de persoane trebuie să fie între 1 și 20")]
        [Display(Name = "Număr Persoane")]
        public int NumarPersoane { get; set; }

        // Relația cu Masa
        [Display(Name = "Masa Alocată")]
        public int? MasaID { get; set; }
        public Masa? Masa { get; set; }

        // Relația cu Clientul
        [Display(Name = "Client")]
        public int? ClientID { get; set; }
        public Client? Client { get; set; }
    }
}