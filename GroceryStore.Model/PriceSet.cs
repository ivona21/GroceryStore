using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryStore.Model
{
    public class PriceSet
    {
        public int Id { get; set; }
        public float Price { get; set; }
        public DateTime Date { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
