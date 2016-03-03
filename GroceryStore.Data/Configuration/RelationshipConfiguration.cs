using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using GroceryStore.Model;

namespace GroceryStore.Data
{
    public class RelationshipConfiguration : EntityTypeConfiguration<Relationship>
    {
        public RelationshipConfiguration()
        {
            HasKey(r => new { r.ProductId, r.CategoryId });

            HasRequired(r => r.Product)
                .WithMany(p => p.Relationships)
                .HasForeignKey(r => r.ProductId);

            HasRequired(r => r.Category)
                .WithMany(c => c.Relationships)
                .HasForeignKey(r => r.CategoryId);
                
        }
    }
}
