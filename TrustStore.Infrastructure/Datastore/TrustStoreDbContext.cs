using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrustStores.Core.Model;

namespace TrustStores.Infrastructure.Datastore
{
    public class TrustStoreDbContext: DbContext
    {
        public TrustStoreDbContext(DbContextOptions<TrustStoreDbContext> options):base(options)
        {
                
        }
        DbSet<Product> products { get; set; }

 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
                .Property(b => b.Price)
                .HasColumnType("Precision(18, 2)");


            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Gucci Bag",
                    Description = "A luxury brand of bag",
                    Category = "Luxury goods",
                    Price = 19999.99M
                });
        }
    }
}
