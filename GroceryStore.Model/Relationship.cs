using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryStore.Model
{
    public class Relationship
    {
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public bool Connected { get; set; }
    }
}
