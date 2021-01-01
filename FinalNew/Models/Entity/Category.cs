using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalHomeSale.Models.Entity
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Home> Homes { get; set; }

    }
}
