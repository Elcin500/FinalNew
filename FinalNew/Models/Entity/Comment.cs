using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalHomeSale.Models.Entity
{
    public class Comment
    {
        public int Id { get; set; }
        [Required]
        public string Message { get; set; }
        public string Author { get; set; }

        public int HomeId { get; set; }
        public virtual Home Home { get; set; }

    }
}
