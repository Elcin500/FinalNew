using FinalNew.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalNew.Models.ViewModels
{
    public class HomeViewModel
    {
        public List<Home> Homes { get; set; }

        public List<Agent> Agents { get; set; }

        public List<Category> Categories { get; set; }
        public AppInfo AppInfos { get; set; }
        public int[] Ids { get; set; }



    }
}
