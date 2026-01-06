using System.ComponentModel.DataAnnotations;

namespace GestiuneRestaurant.Models
{
    public class Rezervare
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Data și ora sunt obligatorii")]
        [Display(Name = "Data și Ora Rezervării")]
        [DataType(DataType.DateTime)]
        public DateTime DataOra { get; set; }

        [Required(ErrorMessage = "Numărul de persoane este obligatoriu")]
        [Range(1, 20, ErrorMessage = "Numărul de persoane trebuie să fie între 1 și 20")]
        [Display(Name = "Nr. Persoane")]
        public int NumarPersoane { get; set; }

        public int? MasaID { get; set; }
        public Masa? Masa { get; set; }

        public int? ClientID { get; set; }
        public Client? Client { get; set; }
    }
}