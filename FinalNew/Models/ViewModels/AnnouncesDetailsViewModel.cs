using FinalHomeSale.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalHomeSale.Models.ViewModels
{
    public class AnnouncesDetailsViewModel
    {
        public Agent Agent { get; set; }

        public Home Home { get; set; }
        public List<Home> Homes { get; set; }
        public AppInfo AppInfo { get; set; }


    }
}
