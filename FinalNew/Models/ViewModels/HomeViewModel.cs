﻿using FinalNew.Models.Entity;
using System.Collections.Generic;

namespace FinalNew.Models.ViewModels
{
    public class HomeViewModel
    {
        public List<Home> Homes { get; set; }

        public PagedViewModel HomesPaged { get; set; }

        public AnnouncesPagedViewModel AnnouncesPaged { get; set; }

        public List<Agent> Agents { get; set; }

        public List<Category> Categories { get; set; }
        public AppInfo AppInfos { get; set; }
        public int[] Ids { get; set; }



    }
}
