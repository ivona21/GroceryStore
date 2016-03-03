using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryStore.Model
{
    public class ProductReport
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public float CurrentPrice { get; set; }
        public float AveragePrice { get; set; }
        public virtual List<Relationship> Relationships { get; set; }
    }
}
