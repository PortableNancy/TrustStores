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
            modelBuilder.Entity<Product>().HasData(
             new Product
             {
                 Id = 1,
                 Name = "Gucci Bag",
                 Description = "A luxury brand of bag",
                 Category = "Luxury goods",

             },
             new Product
             {
                 Id = 2,
                 Name = "AirPod 3",
                 Description = "A portable headphone",
                 Category= "Gadgets"
             },
             new Product
             {
                 Id = 3,
                 Name = "Nike Sneakers",
                 Description = "A comfortable branded shoe",
                 Category = "Shoe"
             }
             );
        }
    }
}
