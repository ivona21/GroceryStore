using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryStore.Model
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public virtual List<Relationship> Relationships { get; set; }
    }
}
