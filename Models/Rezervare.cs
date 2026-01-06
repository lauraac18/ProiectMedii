using System.ComponentModel.DataAnnotations;

namespace GestiuneRestaurant.Models
{
    public class Rezervare
    {
        public int ID { get; set; }

        [Display(Name = "Data și Ora Rezervării")]
        [DataType(DataType.DateTime)]
        public DateTime DataOra { get; set; }

        public int? MasaID { get; set; }
        public Masa? Masa { get; set; }

        public int? ClientID { get; set; }
        public Client? Client { get; set; }
    }
}
