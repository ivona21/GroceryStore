using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using GroceryStore.Model;

namespace GroceryStore.Data
{
    public class GroceryStoreDbContext : DbContext
    {
        public GroceryStoreDbContext() : base(nameOrConnectionString: "DefaultConnection") { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Relationship> Relationships { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<PriceSet> PriceSets { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add<Relationship>(new RelationshipConfiguration());
        }
    }
}
