using FinalNew.Models.Entity.Membership;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace FinalNew.Models.Entity
{
    public class Agent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string Phone2 { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Agency { get; set; }
        public string Description { get; set; }
        public string FacebookLink { get; set; }
        public string InstagramLink { get; set; }
        public string TwitterLink { get; set; }
        public string ImagePath { get; set; }


        [ForeignKey("Owner")]
        public int OwnerId { get; set; }
        public virtual AppUser Owner { get; set; }

        [NotMapped]
        public string ImagePathTemp { get; set; }


        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedDate { get; set; }
    }
}
