using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProiectRestaurant.Models;

namespace GestiuneRestaurant.Data
{
    public class GestiuneRestaurantContext : DbContext
    {
        public GestiuneRestaurantContext (DbContextOptions<GestiuneRestaurantContext> options)
            : base(options)
        {
        }

        public DbSet<ProiectRestaurant.Models.Rezervare> Rezervare { get; set; } = default!;
        public DbSet<ProiectRestaurant.Models.ProdusMeniu> ProdusMeniu { get; set; } = default!;
        public DbSet<ProiectRestaurant.Models.ProdusDestinat> ProdusDestinat { get; set; } = default!;
        public DbSet<ProiectRestaurant.Models.Masa> Masa { get; set; } = default!;
        public DbSet<ProiectRestaurant.Models.Client> Client { get; set; } = default!;
        public DbSet<ProiectRestaurant.Models.CategorieProdus> CategorieProdus { get; set; } = default!;
    }
}
