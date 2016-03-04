using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryStore.Model
{
    public class Product : ProductReport
    {
        public string Name { get; set; }
        public string SKU { get; set; }
        public bool Available { get; set; }
        public virtual List<PriceSet> PriceSets { get; set; }
        public virtual List<Relationship> Relationships { get; set; }

        //
        public int NumberOfPrices { get; set; }
        public float SumOfPrices { get; set; }
    }
}
