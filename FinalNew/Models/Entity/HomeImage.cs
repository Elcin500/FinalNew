using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalNew.Models.Entity
{
    public class HomeImage
    {
        public int Id { get; set; }
        public string Path { get; set; }

        public bool? IsMain { get; set; }

        public int HomeId { get; set; }
        public virtual Home Home { get; set; }
    }
}
