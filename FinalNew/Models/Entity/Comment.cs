using FinalNew.Models.Entity.Membership;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalNew.Models.Entity
{
    public class Comment
    {
        public int Id { get; set; }
        [Required]
        public string Message { get; set; }

        public int OwnerId { get; set; }

        public int HomeId { get; set; }
        public virtual Home Home { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedDate { get; set; }
    }
}
