using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace FinalNew.Models.ViewModels
{
    public class DashBoardViewModel
    {
        public int? HomeCount { get; set; }


        public int? AgentCount { get; set; }

        public int? LastMonthHomeCount { get; set; }

        public IPAddress ip { get; set; }

        public int? TodayHomeCount { get; set; }

        public int? ClientCount { get; set; }

        public int? SubscribesCount { get; set; }


    }
}
