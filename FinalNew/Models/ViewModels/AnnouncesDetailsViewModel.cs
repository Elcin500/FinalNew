using FinalNew.Models.Entity;
using FinalNew.Models.Entity.Membership;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalNew.Models.ViewModels
{
    public class AnnouncesDetailsViewModel
    {
        public Agent Agent { get; set; }

        public Home Home { get; set; }
        public List<Home> Homes { get; set; }
        public AppInfo AppInfo { get; set; }
        public List<AppUser> Owners { get; set; }


    }
}
