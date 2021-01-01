using FinalHomeSale.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalHomeSale.Models.ViewModels
{
    public class AgentViewModel
    {

        public List<Home> Homes { get; set; }

        public Agent Agent { get; set; }
    }
}
