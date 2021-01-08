using FinalNew.Models.Entity.Membership;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FinalNew.Models.Entity
{
    public class Home
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string AnnounceType { get; set; }
        public string Period { get; set; }
        public int Price { get; set; }
        public string Area { get; set; }
        public string LandArea { get; set; }
        public int? RoomCount { get; set; }
        public int? Floor { get; set; }
        public int? BathCount { get; set; }
        public int? GarageCount { get; set; }
        public string SellerName { get; set; }
        public string Phone { get; set; }
        public string Description { get; set; }
        public string Map { get; set; }


        public int? CityId { get; set; }
        public virtual City City { get; set; }

        public int? BakuDistrictId { get; set; }
        public virtual BakuDistrict BakuDistrict { get; set; }

        public int? NMRDistrictId { get; set; }
        public virtual NMRDistrict NMRDistrict { get; set; }

        public int? MetroId { get; set; }
        public virtual Metro Metro { get; set; }

        public int? AgentId { get; set; }
        public virtual Agent Agent { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        [ForeignKey("Owner")]
        public int OwnerId { get; set; }
        public virtual AppUser Owner { get; set; }

        public ICollection<HomeImage> Images { get; set; }

        [NotMapped]
        public IFormFile[] file { get; set; }

        [NotMapped]
        public int fileSelectedIndex { get; set; }

        public ICollection<Comment> Comments { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedDate { get; set; }

    }
}
