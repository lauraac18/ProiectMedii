namespace GestiuneRestaurant.Models
{
    public class ProdusDestinat
    {
        public int ID { get; set; }
        public int ProdusMeniuID { get; set; }
        public ProdusMeniu? ProdusMeniu { get; set; }

        public int CategorieProdusID { get; set; }

        public CategorieProdus? CategorieProdus { get; set; }
    }
}
