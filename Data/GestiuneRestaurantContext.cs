using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GestiuneRestaurant.Models;

namespace GestiuneRestaurant.Data
{
    public class GestiuneRestaurantContext : DbContext
    {
        public GestiuneRestaurantContext (DbContextOptions<GestiuneRestaurantContext> options)
            : base(options)
        {
        }

        public DbSet<GestiuneRestaurant.Models.Rezervare> Rezervare { get; set; } = default!;
        public DbSet<GestiuneRestaurant.Models.ProdusMeniu> ProdusMeniu { get; set; } = default!;
        public DbSet<GestiuneRestaurant.Models.ProdusDestinat> ProdusDestinat { get; set; } = default!;
        public DbSet<GestiuneRestaurant.Models.Masa> Masa { get; set; } = default!;
        public DbSet<GestiuneRestaurant.Models.Client> Client { get; set; } = default!;
        public DbSet<GestiuneRestaurant.Models.CategorieProdus> CategorieProdus { get; set; } = default!;
    }
}
