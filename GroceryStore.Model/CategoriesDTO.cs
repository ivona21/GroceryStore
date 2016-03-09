using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryStore.Model
{
    public class CategoriesDTO
    {
        public int Id { get; set; }
        public bool Connected { get; set; }
        public string CategoryName { get; set; }
    }
}
