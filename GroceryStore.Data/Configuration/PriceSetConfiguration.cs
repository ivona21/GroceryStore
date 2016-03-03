using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using GroceryStore.Model;

namespace GroceryStore.Data
{
    public class PriceSetConfiguration : EntityTypeConfiguration<PriceSet>
    {
        public PriceSetConfiguration()
        {
            HasRequired(ps => ps.Product)
                .WithMany(p => p.PriceSets)
                .HasForeignKey(ps => ps.ProductId);
        }
    }
}
